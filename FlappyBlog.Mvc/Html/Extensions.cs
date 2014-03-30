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