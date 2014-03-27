using System;
using System.Data;

namespace FlappyBlog.Mvc.Core
{
    public class IsolationLevelAttribute : Attribute
    {
        public IsolationLevelAttribute(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            IsolationLevel = isolationLevel;
        }

        public IsolationLevel IsolationLevel { get; private set; }
    }
}