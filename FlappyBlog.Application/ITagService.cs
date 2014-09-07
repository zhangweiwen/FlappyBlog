using FlappyBlog.Domain.Models;
using FlappyBlog.Infrastructure.Paged;

namespace FlappyBlog.Application
{
    public interface ITagService
    {
        void CreateTag(Tag tag);
        void CreateTags(string tags);
        void RemoveTag(string tagName);
        PagedList<Tag> Query(string keyword, PagedInfo pagedInfo);
    }
}