using System;
using System.Diagnostics;
using System.Linq;
using Castle.DynamicProxy;
using FlappyBlog.Infrastructure.Exceptions;
using NLog;

// ReSharper disable once CheckNamespace
namespace FlappyBlog.Infrastructure.Aop
{
    public sealed class LogInterceptor : IInterceptor
    {
        private const string EntryMethodKey = "App_Service_Entry_Method";
        private static readonly Logger Logger = LogManager.GetLogger("application");

        public void Intercept(IInvocation invocation)
        {
            var currentMethodName = AopHelper.GetMethodName(invocation);
            if (MappedDiagnosticsContext.Contains(EntryMethodKey) == false)
                MappedDiagnosticsContext.Set(EntryMethodKey, currentMethodName);

            var entryMethodName = MappedDiagnosticsContext.Get(EntryMethodKey);
            Debug.Assert(entryMethodName != null);
            try
            {
                NestedDiagnosticsContext.Push(currentMethodName);
                var arguments = invocation.Arguments ?? new object[] { };
                var argumentString = string.Join(", ", arguments.Select(x => x == null ? "null" : x.ToString()));
                Logger.Info("Parameters => {0}", argumentString);

                invocation.Proceed();

                var result = "NullOrVoid";
                if (invocation.ReturnValue != null)
                    result = invocation.ReturnValue.ToString();

                Logger.Info("Result => {0}", result);
            }
            catch (Exception exception)
            {
                if (currentMethodName.Equals(entryMethodName))
                {
                    if (exception is DomainException)
                    {
                        Logger.Warn(exception);
                    }
                    else
                    {
                        Logger.Error(exception);                        
                    }
                }

                throw;
            }
            finally
            {
                NestedDiagnosticsContext.Pop();
                if (currentMethodName.Equals(entryMethodName))
                    MappedDiagnosticsContext.Remove(EntryMethodKey);
            }
        }
    }
}