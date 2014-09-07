using System;

namespace FlappyBlog.Domain.Models
{
    public partial class User : DomainObject
    {
        public virtual bool Active { get; set; }

        public virtual string Email { get; set; }

        public virtual string NickName { get; set; }

        public virtual string Password { get; set; }

        public virtual string HomePage { get; set; }

        public virtual string PictrueUrl { get; set; }

        public virtual string Description { get; set; }
    }

    public partial class User
    {
        public virtual Role Role { get; set; }

        public virtual int PostCount { get; set; }

        public virtual int CommentCount { get; set; }
    }
}