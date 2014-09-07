using System;
using Newtonsoft.Json;

namespace FlappyBlog.Domain.Models
{
    [Serializable]
    public partial class DomainObject
    {
        public virtual int Id { get; set; }

        public virtual DateTime CreatedDate { get; set; }

        public virtual DateTime UpdatedDate { get; set; }
    }

    public partial class DomainObject
    {
        public override int GetHashCode()
        {
            return Id.GetHashCode();
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
            return Id.Equals(other.Id);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}