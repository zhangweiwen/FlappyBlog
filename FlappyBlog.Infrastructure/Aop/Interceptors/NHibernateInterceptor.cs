using System;
using System.Data;
using Castle.Core.Internal;
using Castle.DynamicProxy;
using NHibernate;
using NHibernate.Context;
using NLog;

// ReSharper disable once CheckNamespace
namespace FlappyBlog.Infrastructure.Aop
{
    public class NHibernateInterceptor : Castle.DynamicProxy.IInterceptor
    {
        private readonly ISessionFactory _sessionFactory;
        private const string SessionOpenedKey = @"Session_Has_Been_Opened";

        public NHibernateInterceptor(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public void Intercept(IInvocation invocation)
        {

            if (MappedDiagnosticsContext.Contains(SessionOpenedKey))
            {
                invocation.Proceed();
                return;
            }

            MappedDiagnosticsContext.Set(SessionOpenedKey, true.ToString());
            ITransaction transaction = null;
            try
            {
                var session = _sessionFactory.OpenSession();
                CurrentSessionContext.Bind(session);
                if (NoTransaction(invocation))
                {
                    invocation.Proceed();
                }
                else
                {
                    var level = IsolationLevel.Unspecified;
                    var levelAttribute = invocation.MethodInvocationTarget.GetAttribute<IsolationLevelAttribute>();
                    if (levelAttribute != null)
                    {
                        level = levelAttribute.IsolationLevel;
                    }
                    transaction = session.BeginTransaction(level);

                    invocation.Proceed();

                    transaction.Commit();
                }
            }
            catch (Exception)
            {
                if (transaction != null)
                    transaction.Rollback();

                throw;
            }
            finally
            {
                if (transaction != null && transaction.IsActive)
                    transaction.Dispose();

                var session = CurrentSessionContext.Unbind(_sessionFactory);
                if (session != null && session.IsOpen)
                {
                    session.Flush();
                    session.Close();
                }
                MappedDiagnosticsContext.Remove(SessionOpenedKey);
            }
        }

        private static bool NoTransaction(IInvocation invocation)
        {
            return invocation.TargetType.HasAttribute<NoTransactionAttribute>() ||
                   invocation.MethodInvocationTarget.HasAttribute<NoTransactionAttribute>();
        }
    }
}