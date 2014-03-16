namespace FlappyBlog.Domain.Models
{
    public class Role : DomainObject
    {
        public virtual string Name { get; set; }

        public virtual string Operations { get; set; }
    }
}