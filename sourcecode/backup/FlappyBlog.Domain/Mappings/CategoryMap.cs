using FlappyBlog.Domain.Models;
using FluentNHibernate.Mapping;

namespace FlappyBlog.Domain.Mappings
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Order).Column("OrderBy");
            Map(x => x.PostCount);
            Map(x => x.Description);
            Map(x => x.CreatedDate);
            Map(x => x.UpdatedDate);
        }
    }
}