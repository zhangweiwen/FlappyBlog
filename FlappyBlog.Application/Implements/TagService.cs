using System;
using System.Collections.Generic;
using System.Linq;
using FlappyBlog.Domain.Models;
using FlappyBlog.Infrastructure.Exceptions;
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
                        PostCount = 0
                    };
                    Session.Save(tagObj);
                }
            }
        }

        //结果写入缓存
        public List<Tag> Query()
        {
            return Session.Query<Tag>().ToList();
        }
    }
}