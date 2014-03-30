using System;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using FlappyBlog.Mvc.Html.Bootstrap;
using FlappyBlog.Mvc.Html.Bootstrap.Btn;

namespace FlappyBlog.Mvc.Html
{
    public static partial class Extensions
    {
        public static MvcHtmlString Toolbar(this HtmlHelper htmlHelper, params Button[] buttons)
        {
            return htmlHelper.Partial("Toolbar", buttons);
        }

        public static Table BeginTable(this HtmlHelper htmlHelper)
        {
            return new Table(htmlHelper.ViewContext);
        }

        public static MvcHtmlString Pager(this HtmlHelper htmlHelper, int pageIndex, int pageCount)
        {
            var wapper = new TagBuilder("div");
            wapper.AddCssClass("pagination-wapper");
            wapper.AddCssClass("text-right");
            var ul = new TagBuilder("ul");
            ul.AddCssClass("pagination");
            var tuple = CountBeginEnd(pageIndex, pageCount);
            var sb = new StringBuilder();
            var prev = new TagBuilder("li");
            var next = new TagBuilder("li");
            var actionName = htmlHelper.ViewContext.Controller.ValueProvider.GetValue("action").RawValue.ToString();
            if (pageIndex == 1)
            {
                prev.AddCssClass("disabled");
                var prevLink = new TagBuilder("a");
                prevLink.SetInnerText("« Prev");
                prev.InnerHtml = prevLink.ToString();

            }
            else
            {
                var prevLink = htmlHelper.ActionLink("« Prev", actionName, new { pageIndex = pageIndex - 1 });
                prev.InnerHtml = prevLink.ToHtmlString();
            }
            if (pageIndex == pageCount)
            {
                next.AddCssClass("disabled");
                var nextLink = new TagBuilder("a");
                nextLink.SetInnerText("Next »");
                next.InnerHtml = nextLink.ToString();
            }
            else
            {
                var nextLink = htmlHelper.ActionLink("Next »", actionName, new { pageIndex = pageIndex + 1 });
                next.InnerHtml = nextLink.ToHtmlString();
            }
            sb.AppendLine(prev.ToString());
            for (var i = tuple.Item1; i <= tuple.Item2; i++)
            {
                var li = new TagBuilder("li");
                var link = htmlHelper.ActionLink(i.ToString(), actionName, new { pageIndex = i });
                if (i == pageIndex)
                {
                    li.AddCssClass("active");
                }
                li.InnerHtml = link.ToHtmlString();
                sb.AppendLine(li.ToString());
            }
            sb.AppendLine(next.ToString());
            ul.InnerHtml = sb.ToString();
            wapper.InnerHtml = ul.ToString();
            return new MvcHtmlString(wapper.ToString());
        }

        public static Tuple<int, int> CountBeginEnd(int pageIndex, int pageCount)
        {
            if (pageCount <= 5)
                return Tuple.Create(1, pageCount);

            if (pageIndex <= 3)
                return Tuple.Create(1, 5);

            if (pageIndex + 2 >= pageCount)
                return Tuple.Create(pageCount - 4, pageCount);

            return Tuple.Create(pageIndex - 2, pageIndex + 2);
        }
    }

    public static partial class Extensions
    {
        public static Button Button(this HtmlHelper htmlHelper, string text)
        {
            return new Button { Text = text };
        }

        public static Button Type(this Button btn, BtnType type)
        {
            btn.Type = type;
            return btn;
        }

        public static Button Size(this Button btn, BtnSize size)
        {
            btn.Size = size;
            return btn;
        }

        public static Button IsBlock(this Button btn, bool isBlock)
        {
            btn.IsBlock = isBlock;
            return btn;
        }

        public static Button IsActive(this Button btn, bool isActive)
        {
            btn.IsActive = isActive;
            return btn;
        }
    }
}