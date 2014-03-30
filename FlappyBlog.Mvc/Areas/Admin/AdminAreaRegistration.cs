using System.Web.Mvc;

namespace FlappyBlog.Mvc.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_login",
                "Admin/Login",
                new { controller = "Home", action = "Login" },
                new[] { "FlappyBlog.Mvc.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                "Admin_password",
                "Admin/Password",
                new { controller = "Home", action = "password" },
                new[] { "FlappyBlog.Mvc.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "FlappyBlog.Mvc.Areas.Admin.Controllers" }
            );
        }
    }
}
