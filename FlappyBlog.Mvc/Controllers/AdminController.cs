using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlappyBlog.Application;

namespace FlappyBlog.Mvc.Controllers
{
    public partial class AdminController : Controller
    {
        private readonly ITagService _tagService;

        //public AdminController(ITagService tagService)
        //{
        //    Debug.Assert(tagService != null);
        //    _tagService = tagService;
        //}
    }

    public partial class AdminController
    {
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Password()
        {
            return View();
        }
    }

    //Tag
    public partial class AdminController
    {
        public ActionResult Tag()
        {
            //var tags = _tagService.Query();
            return View();
        }
    }
}