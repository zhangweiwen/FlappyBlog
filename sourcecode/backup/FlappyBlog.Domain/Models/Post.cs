using System;
using System.Collections.Generic;

namespace FlappyBlog.Domain.Models
{
    public partial class Post : DomainObject
    {
        public virtual string Title { get; set; }

        public virtual int VisitCount { get; set; }

        public virtual string Content { get; set; }

        public virtual string Summary { get; set; }

        public virtual UrlType UrlType { get; set; }

        public virtual int CommentCount { get; set; }

        public virtual string CustomUrl { get; set; }


    }

    public partial class Post
    {
        public virtual User User { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }        
    }

    public partial class Post
    {
        public virtual bool Top { get; set; }

        public virtual bool Draft { get; set; }

        public virtual bool Private { get; set; }

        public virtual bool Recommend { get; set; }

        public virtual bool DisableComment { get; set; }

    }
}