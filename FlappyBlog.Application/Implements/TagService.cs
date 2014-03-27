using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FlappyBlog.Domain.Models;
using FlappyBlog.Infrastructure.Exceptions;
using NHibernate;
using NHibernate.Linq;
using NLog;

namespace FlappyBlog.Application.Implements
{
    public sealed partial class TagService : BaseAppService, ITagService
    {
        private readonly ISession _session;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public TagService(ISession session)
        {
            Debug.Assert(session != null);
            _session = session;
        }
    }

    public partial class TagService
    {
        public void CreateTag(Tag tag)
        {
            var exist = _session.Query<Tag>().Any(x => x.Name == tag.Name);
            if (exist)
                throw new DomainException(string.Format("{0} 已存在!", tag.Name));

            _session.Save(tag);
        }

        public void CreateTags(string tags)
        {
            var tagList = tags.Split(',');
            var tagsInDb = _session.Query<Tag>().ToList();
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
                    _session.Save(tagObj);
                }
            }
        }

        //结果写入缓存
        public List<Tag> Query()
        {
            return _session.Query<Tag>().ToList();
        }
    }
}