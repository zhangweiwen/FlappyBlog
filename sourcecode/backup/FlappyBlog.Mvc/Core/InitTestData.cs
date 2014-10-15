using System;
using System.Collections.Generic;
using FlappyBlog.Domain.Models;

namespace FlappyBlog.Mvc.Core
{
    public static partial class InitTestData
    {
        private static readonly List<Tag> TagList = new List<Tag>();

        public static List<Tag> Tags { get { return TagList; } }
    }

    public static partial class InitTestData
    {
        static InitTestData()
        {
            InitTag();
        }

        private static void InitTag()
        {
            for (var i = 0; i < 100; i++)
            {
                var tagName = "Tag" + i;
                TagList.Add(new Tag
                {
                    Name = tagName,
                    CreatedDate = DateTime.Now,
                    Description = tagName,
                    PostCount = i,
                    UpdatedDate = DateTime.Now.AddHours(i),
                });
            }
        }
    }
}