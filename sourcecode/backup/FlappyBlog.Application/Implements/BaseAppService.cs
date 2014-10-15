using System.Collections.Generic;
using NHibernate;
using NHibernate.Context;

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

        protected ISession Session
        {
            get
            {
                return SessionFactory.GetCurrentSession();
            }
        }

        public ISessionFactory SessionFactory { get; set; }
    }
}