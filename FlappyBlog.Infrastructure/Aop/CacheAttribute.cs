using System;

namespace FlappyBlog.Infrastructure.Aop
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class CacheAttribute : Attribute
    {
        public CacheAttribute()
        {
            Duration = 60;
        }

        public int Duration { get; set; }
    }
}