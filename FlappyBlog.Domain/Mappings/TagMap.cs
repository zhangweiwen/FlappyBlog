using FlappyBlog.Domain.Models;
using FluentNHibernate.Mapping;

namespace FlappyBlog.Domain.Mappings
{
    public class TagMap : ClassMap<Tag>
    {
        public TagMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.PostCount);
            Map(x => x.Description);
            Map(x => x.CreatedDate);
        }
    }
}