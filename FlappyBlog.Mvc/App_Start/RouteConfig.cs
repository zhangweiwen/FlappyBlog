using System.Web.Mvc;
using System.Web.Routing;

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
                 namespaces: new[] { "FlappyBlog.Mvc.Areas.Home.Controllers" }
             );
            route.DataTokens["area"] = "Home";
        }
    }
}