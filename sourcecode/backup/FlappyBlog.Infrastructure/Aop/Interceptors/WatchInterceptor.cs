using System.Diagnostics;
using Castle.DynamicProxy;
using NLog;

// ReSharper disable once CheckNamespace
namespace FlappyBlog.Infrastructure.Aop
{
    public class WatchInterceptor : IInterceptor
    {
        private static readonly Logger Logger = LogManager.GetLogger("analyze");

        public void Intercept(IInvocation invocation)
        {
            var watch = Stopwatch.StartNew();
            try
            {
                invocation.Proceed();
            }
            finally
            {
                watch.Stop();
                LogElapsed(invocation, watch);
            }
        }

        private static void LogElapsed(IInvocation invocation, Stopwatch watch)
        {
            const string format = "{0}, {1}";
            var methodName = AopHelper.GetMethodName(invocation);
            Logger.Info(string.Format(format, methodName, watch.Elapsed));
        }
    }
}