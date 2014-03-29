using Castle.DynamicProxy;

namespace FlappyBlog.Infrastructure.Aop
{
    internal class AopHelper
    {
        internal static string GetMethodName(IInvocation invocation)
        {
            var methodName = invocation.Method.Name;
            var className = invocation.Method.ReflectedType.Name;
            return string.Format("{0}.{1}", className, methodName);
        }

        internal static string MergeKey(IInvocation invocation, string key)
        {
            const string format = "{0}_{1}";
            return string.Format(format, GetMethodName(invocation), key);
        }
    }
}