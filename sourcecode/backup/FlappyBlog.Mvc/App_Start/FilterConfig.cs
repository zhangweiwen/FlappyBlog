using System.Web.Mvc;

// ReSharper disable once CheckNamespace
namespace FlappyBlog.Mvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}