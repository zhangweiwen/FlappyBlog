using System;

namespace FlappyBlog.Domain.Models
{
    public class Category : DomainObject
    {
        public virtual int Order { get; set; }

        public virtual string Name { get; set; }

        public virtual int PostCount { get; set; }

        public virtual string Description { get; set; }

        public virtual DateTime CreatedDate { get; set; }
    }
}