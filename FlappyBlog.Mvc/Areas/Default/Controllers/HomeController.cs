using System;
using System.Linq;
using System.Web.Mvc;
using FlappyBlog.Application;
using FlappyBlog.Domain.Models;
using FlappyBlog.Mvc.App_Start;
using FlappyBlog.Mvc.Core;

namespace FlappyBlog.Mvc.Areas.Default.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITagService _tagService;

        public HomeController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public ActionResult Index()
        {
            //var tag = _tagService.Query().Items.FirstOrDefault();
            return View(new Tag { Name = "TagAbc" });
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
                foreach (var tag in InitTestData.Tags)
                {
                    var id = session.Save(tag);
                }
                session.Flush();
            }
            return Content("Success!");
        }
    }
}