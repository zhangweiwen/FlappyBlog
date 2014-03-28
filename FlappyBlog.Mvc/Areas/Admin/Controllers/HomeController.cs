using System.Web.Mvc;

namespace FlappyBlog.Mvc.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}