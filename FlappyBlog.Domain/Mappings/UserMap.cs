using FlappyBlog.Domain.Models;
using FluentNHibernate.Mapping;

namespace FlappyBlog.Domain.Mappings
{
    public sealed class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id);
            Map(x => x.Email);
            Map(x => x.Active);
            Map(x => x.NickName);
            Map(x => x.Password);
            Map(x => x.HomePage);
            Map(x => x.PostCount);
            Map(x => x.PictrueUrl);
            Map(x => x.Description);
            Map(x => x.CreatedDate);
            Map(x => x.CommentCount);

            References(x => x.Role);
        }
    }
}