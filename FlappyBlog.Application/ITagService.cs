using System.Collections.Generic;
using FlappyBlog.Domain.Models;

namespace FlappyBlog.Application
{
    public interface ITagService
    {
        void CreateTag(Tag tag);
        void CreateTags(string tags);
        List<Tag> Query();
    }
}