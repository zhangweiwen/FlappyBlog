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

        public ActionResult Index(int? pageIndex = 1)
        {
            var pagedInfo = new PagedInfo()
            {
                PageIndex = 1,
                PageSize = Constants.PageSize
            };
            var tags = _tagService.Query(pagedInfo);
            return View(tags);
        }
    }
}