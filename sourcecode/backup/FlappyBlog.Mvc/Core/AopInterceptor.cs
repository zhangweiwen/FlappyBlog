using System;
using Castle.DynamicProxy;
using NHibernate;
using NHibernate.Context;

namespace FlappyBlog.Mvc.Core
{
    public class AopInterceptor : Castle.DynamicProxy.IInterceptor
    {
        protected event Action<IInvocation> BeforeInvocationProceed;
        protected event Action<IInvocation> AfterInvocationProceed;
        protected event Action<IInvocation, Exception> InvocationProceedThrowException;

        public AopInterceptor()
        {
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                if (BeforeInvocationProceed != null)
                    BeforeInvocationProceed(invocation);

                invocation.Proceed();

                if (AfterInvocationProceed != null)
                    AfterInvocationProceed(invocation);
            }
            catch (Exception exception)
            {
                if (InvocationProceedThrowException != null)
                    InvocationProceedThrowException(invocation, exception);
            }
        }
    }
}