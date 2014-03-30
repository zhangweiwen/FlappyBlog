using System.Web.Mvc;
using FlappyBlog.Application;
using FlappyBlog.Infrastructure.Paged;
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
            if (pageIndex <= 0)
                pageIndex = 1;

            var pagedInfo = new PagedInfo
            {
                PageIndex = pageIndex,
                PageSize = Constants.PageSize
            };
            var tags = _tagService.Query(keyword, pagedInfo);
            return View(tags);
        }
    }
}