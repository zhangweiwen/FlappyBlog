using System.Diagnostics;
using System.Web.Mvc;
using Autofac;
using FlappyBlog.Mvc.App_Start;
using NHibernate;
using NHibernate.Context;

namespace FlappyBlog.Mvc.Core
{
    public class SessionPerRequestAttribute : ActionFilterAttribute
    {
        private const string ActionNameKey = @"OpenSessionActionName";
        private const string ControllerNameKey = @"OpenSessionControllerName";

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sessionFactory = IocHelper.Container.Resolve<ISessionFactory>();
            if (CurrentSessionContext.HasBind(sessionFactory))
                return;

            var session = sessionFactory.OpenSession();
            CurrentSessionContext.Bind(session);
            var httpSession = filterContext.HttpContext.Session;
            Debug.Assert(httpSession != null);
            httpSession[ActionNameKey] = filterContext.ActionDescriptor.ActionName;
            httpSession[ControllerNameKey] = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var httpSession = filterContext.HttpContext.Session;
            Debug.Assert(httpSession != null);
            var action = httpSession[ActionNameKey].ToString();
            var controller = httpSession[ActionNameKey].ToString();
            var actualAction = filterContext.ActionDescriptor.ActionName;
            var actualController = filterContext.ActionDescriptor.ActionName;
            if (action != actualAction || controller != actualController)
                return;

            var sessionFactory = IocHelper.Container.Resolve<ISessionFactory>();
            var session = CurrentSessionContext.Unbind(sessionFactory);
            if (session != null)
            {
                session.Flush();
                session.Close();
                session.Dispose();
            }
        }
    }
}