using System;
using System.Data;

namespace FlappyBlog.Infrastructure.Aop
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class IsolationLevelAttribute : Attribute
    {
        public IsolationLevelAttribute(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            IsolationLevel = isolationLevel;
        }

        public IsolationLevel IsolationLevel { get; private set; }
    }
}