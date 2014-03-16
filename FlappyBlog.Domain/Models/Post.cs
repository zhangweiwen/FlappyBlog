using System;
using System.Collections.Generic;

namespace FlappyBlog.Domain.Models
{
    public partial class Post : DomainObject
    {
        public virtual string Title { get; set; }

        public virtual int ViewCount { get; set; }

        public virtual string Context { get; set; }

        public virtual string Summary { get; set; }

        public virtual UrlType UrlType { get; set; }

        public virtual int CommentCount { get; set; }

        public virtual string CustomerUrl { get; set; }

        public virtual DateTime CreatedDate { get; set; }

        public virtual DateTime UpdatedDate { get; set; }
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

    public partial class Post
    {

    }
}