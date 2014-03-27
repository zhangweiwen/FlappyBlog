using System.Web.Mvc;
using FlappyBlog.Mvc.Core;

namespace FlappyBlog.Mvc.Controllers
{
    [SessionPerRequest]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}