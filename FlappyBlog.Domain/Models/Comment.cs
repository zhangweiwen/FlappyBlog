using System;

namespace FlappyBlog.Domain.Models
{
    public class Comment : DomainObject
    {
        public virtual User User { get; set; }
        
        public virtual Post Post { get; set; }

        public virtual string IP { get; set; }

        public virtual string Name { get; set; }

        public virtual string Agent { get; set; }

        public virtual string Email { get; set; }

        public virtual bool Approved { get; set; }

        public virtual string Content { get; set; }
        
        public virtual Comment Parent { get; set; }

        public virtual string HomePage { get; set; }

        public virtual DateTime CreatedDate { get; set; }
    }
}