using FlappyBlog.Domain.Models;
using FluentNHibernate.Mapping;

namespace FlappyBlog.Domain.Mappings
{
    public class CommentMap : ClassMap<Comment>
    {
        public CommentMap()
        {
            Id(x => x.Id);
            Map(x => x.IP);
            Map(x => x.Name);
            Map(x => x.Agent);
            Map(x => x.Email);
            Map(x => x.Content);
            Map(x => x.HomePage);
            Map(x => x.Approved);
            Map(x => x.CreatedDate);
            Map(x => x.UpdatedDate);

            References(x => x.User);
            References(x => x.Post);
            References(x => x.Parent);
        }
    }
}