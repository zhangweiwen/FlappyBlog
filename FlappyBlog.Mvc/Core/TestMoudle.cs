using System;
using System.Web;
using NLog;

namespace FlappyBlog.Mvc
{
    public class TestMoudle : IHttpModule
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public void Init(HttpApplication context)
        {
            context.BeginRequest += OnBeginRequest;
        }

        private void OnBeginRequest(object sender, EventArgs e)
        {
            Logger.Info(HttpContext.Current.Request.Url);
        }

        public void Dispose()
        {
        }
    }
}