using FlappyBlog.Domain.Models;
using FluentNHibernate.Mapping;

namespace FlappyBlog.Domain.Mappings
{
    public class PostMap : ClassMap<Post>
    {
        public PostMap()
        {
            Id(x => x.Id);
            Map(x => x.Top);
            Map(x => x.Title);
            Map(x => x.Draft);
            Map(x => x.Private);
            Map(x => x.Content);
            Map(x => x.Summary);
            Map(x => x.UrlType);
            Map(x => x.Recommend);
            Map(x => x.CustomUrl);
            Map(x => x.VisitCount);
            Map(x => x.CreatedDate);
            Map(x => x.UpdatedDate);
            Map(x => x.CommentCount);
            Map(x => x.DisableComment);

            References(x => x.User);
            References(x => x.Category);

            HasMany(x => x.Tags);
        }
    }
}