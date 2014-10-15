using Castle.Core.Internal;
using Castle.DynamicProxy;

// ReSharper disable once CheckNamespace
namespace FlappyBlog.Infrastructure.Aop
{
    public class CacheInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var typeAttribute = invocation.TargetType.GetAttribute<CacheAttribute>();
            var methodAttribute = invocation.MethodInvocationTarget.GetAttribute<CacheAttribute>();
            if (methodAttribute != null)
            {
                //TODO:?
            }
            if (typeAttribute != null)
            {
                
            }
        }

    }
}