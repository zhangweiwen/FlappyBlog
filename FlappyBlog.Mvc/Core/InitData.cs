using System;
using System.Collections.Generic;
using FlappyBlog.Domain.Models;
using FluentNHibernate.Testing.Values;

namespace FlappyBlog.Mvc.Core
{
    public static partial class InitData
    {
        private static readonly List<Tag> TagList = new List<Tag>();

        public static List<Tag> Tags { get { return TagList; } }
    }

    public static partial class InitData
    {
        static InitData()
        {
            InitTag();
        }

        private static void InitTag()
        {
            TagList.Add(new Tag
            {
                Name = "默认标签",//TODO:国际化
                CreatedDate = DateTime.Now,
                Description = "默认标签",
                PostCount = 0
            });
        }
    }
}