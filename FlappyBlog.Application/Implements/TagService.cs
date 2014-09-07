using System;
using System.Linq;
using System.Linq.Dynamic;
using FlappyBlog.Domain.Models;
using FlappyBlog.Infrastructure.Exceptions;
using FlappyBlog.Infrastructure.Extensions.String;
using FlappyBlog.Infrastructure.Paged;
using NHibernate.Linq;
using NLog;

namespace FlappyBlog.Application.Implements
{
    public sealed class TagService : BaseAppService, ITagService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public void CreateTag(Tag tag)
        {
            var exist = Session.Query<Tag>().Any(x => x.Name == tag.Name);
            if (exist)
                throw new DomainException(string.Format("{0} 已存在!", tag.Name));

            tag.CreatedDate = DateTime.Now;
            tag.UpdatedDate = DateTime.Now;
            Session.Save(tag);
        }

        public void CreateTags(string tags)
        {
            var tagList = tags.Split(',');
            var tagsInDb = Session.Query<Tag>().ToList();
            foreach (var tag in tagList)
            {
                if (string.IsNullOrWhiteSpace(tag) == false && tagsInDb.Exists(x => x.Name == tag.Trim()) == false)
                {
                    var tagObj = new Tag
                    {
                        CreatedDate = DateTime.Now,
                        Description = tag,
                        Name = tag,
                        PostCount = 0,
                        UpdatedDate = DateTime.Now,
                    };
                    Session.Save(tagObj);
                }
            }
        }

        public void RemoveTag(string tagName)
        {
            var tags = Session.QueryOver<Tag>().Where(x => x.Name == tagName).List();
            foreach (var tag in tags)
            {
                Session.Delete(tag);
            }
        }

        //结果写入缓存
        public PagedList<Tag> Query(string keyword, PagedInfo pagedInfo)
        {
            var query = Session.Query<Tag>();
            if (keyword.IsNullOrWhiteSpace() == false)
            {
                query = query.Where(q => q.Name.Contains(keyword) || q.Description.Contains(keyword));
            }
            return query.ToPagedList(pagedInfo);
        }
    }
}