using System;
using System.Linq;
using System.Web;
using Castle.DynamicProxy;
using NHibernate;
using NHibernate.Context;
using NHibernate.Util;

namespace FlappyBlog.Mvc.Core
{
    public class TransactionInterceptor : Castle.DynamicProxy.IInterceptor
    {
        private readonly ISessionFactory _sessionFactory;
        private const string OpenedKey = @"TransactionHasBeenOpened";

        public TransactionInterceptor(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public void Intercept(IInvocation invocation)
        {
            var opened = HttpContext.Current.Session[OpenedKey];
            if (opened != null && ((bool)opened))
                return;

            HttpContext.Current.Session[OpenedKey] = true;
            var session = _sessionFactory.GetCurrentSession();
            var transaction = session.BeginTransaction();
            try
            {
                invocation.Proceed();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Commit();
            }
        }
    }
}