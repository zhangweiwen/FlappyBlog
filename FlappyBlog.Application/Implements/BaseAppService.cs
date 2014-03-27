using System.Collections.Generic;

namespace FlappyBlog.Application.Implements
{
    public abstract class BaseAppService
    {
        private readonly List<string> _messages = new List<string>();

        protected List<string> Messages
        {
            get
            {
                return _messages;
            }
        }
    }
}