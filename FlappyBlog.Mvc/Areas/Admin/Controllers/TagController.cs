using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FlappyBlog.Application;
using FlappyBlog.Domain.Models;
using FlappyBlog.Infrastructure.Exceptions;
using FlappyBlog.Infrastructure.Paged;
using FlappyBlog.Mvc.Areas.Admin.Models;
using FlappyBlog.Mvc.Core;

namespace FlappyBlog.Mvc.Areas.Admin.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public ActionResult Index(string keyword, int pageIndex = 1)
        {
            return View("Index");
        }

        public ActionResult List(string keyword, int pageIndex = 1)
        {
            var tags = GetTagList(keyword, pageIndex);
            return View("TagList", tags);
        }

        private PagedList<Tag> GetTagList(string keyword, int pageIndex)
        {
            if (pageIndex <= 0)
                pageIndex = 1;

            var pagedInfo = new PagedInfo
            {
                PageIndex = pageIndex,
                PageSize = Constants.PageSize,
            };
            return _tagService.Query(keyword, pagedInfo);
        }

        public ActionResult Create(TagEditModel model)
        {
            _tagService.CreateTag(new Tag
            {
                CreatedDate = DateTime.Now,
                Description = model.Description,
                Name = model.Name,
                PostCount = 0
            });
            return Json(new { title = "Success", content = "创建标签成功！" });
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (ModelState.IsValid == false && Request.IsPost() && Request.IsAjaxRequest())
            {
                filterContext.Result = new JsonResult
                {
                    Data = ModelState.Values.SelectMany(x => x.Errors.Select(o => o.ErrorMessage))
                };
            }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            var domainException = filterContext.Exception as DomainException;
            if (domainException != null && Request.IsAjaxRequest())
            {
                ModelState.AddModelError("DomainException", domainException.Message);
                filterContext.Result = new JsonResult
                {
                    Data = ModelState.Values.SelectMany(x => x.Errors.Select(o => o.ErrorMessage))
                };
                filterContext.ExceptionHandled = true;
            }
            base.OnException(filterContext);
        }
    }
}