using System;

namespace FlappyBlog.Domain.Models
{
    [Serializable]
    public partial class DomainObject
    {
        public virtual int ID { get; set; }
    }

    public partial class DomainObject
    {
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != GetType())
                return false;

            return Equals((DomainObject)obj);
        }

        protected bool Equals(DomainObject other)
        {
            return ID.Equals(other.ID);
        }
    }
}