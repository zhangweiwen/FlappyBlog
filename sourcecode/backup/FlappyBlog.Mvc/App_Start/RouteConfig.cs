using System.Web.Mvc;
using System.Web.Routing;

// ReSharper disable once CheckNamespace
namespace FlappyBlog.Mvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            var route = routes.MapRoute(
                 name: "Default",
                 url: "{controller}/{action}/{id}",
                 defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "FlappyBlog.Mvc.Areas.Default.Controllers" }
             );
            route.DataTokens["area"] = "Default";
        }
    }
}