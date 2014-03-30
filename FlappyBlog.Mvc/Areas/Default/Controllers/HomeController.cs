using System;
using System.Web.Mvc;
using FlappyBlog.Domain.Models;
using FlappyBlog.Mvc.App_Start;
using FlappyBlog.Mvc.Core;

namespace FlappyBlog.Mvc.Areas.Default.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new Tag
            {
                Name = "123"
            });
        }

        public ActionResult About()
        {
            return View();
        }

        //[Authorize]
        public ActionResult InitDb()
        {
            var factory = IocHelper.BuildSessionFactory(true);
            using (var session = factory.OpenSession())
            {
                foreach (var tag in InitData.Tags)
                {
                   var id = session.Save(tag);
                    session.Flush();
                    Console.WriteLine(id);
                }
            }
            return Content("Success!");
        }
    }
}