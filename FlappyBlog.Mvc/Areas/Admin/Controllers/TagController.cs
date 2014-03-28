using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlappyBlog.Mvc.Areas.Admin.Controllers
{
    public class TagController : Controller
    {
        //
        // GET: /Admin/Tag/

        public ActionResult Index()
        {
            return View();
        }

    }
}
