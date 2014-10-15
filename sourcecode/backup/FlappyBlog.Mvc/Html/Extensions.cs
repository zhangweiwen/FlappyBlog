using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Collections.Specialized;
using System.Web.Routing;

namespace FlappyBlog.Mvc.Html
{
    public static partial class Extensions
    {
        public static Table BeginTable(this HtmlHelper htmlHelper)
        {
            return new Table(htmlHelper.ViewContext);
        }

        public static MvcHtmlString Pager(this HtmlHelper htmlHelper, int pageIndex, int pageCount)
        {
            if (pageCount == 0)
            {
                return MvcHtmlString.Empty;
            }
            var request = htmlHelper.ViewContext.HttpContext.Request;
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
            if (htmlHelper.ViewContext.IsChildAction)
            {
                actionName =
                    htmlHelper.ViewContext.ParentActionViewContext.Controller.ValueProvider.GetValue("action")
                        .RawValue.ToString();
            }
            if (pageIndex == 1)
            {
                prev.AddCssClass("disabled");
                var prevLink = new TagBuilder("a");
                prevLink.SetInnerText("« Prev");
                prev.InnerHtml = prevLink.ToString();
            }
            else
            {
                var dic = request.QueryString.ToRouteValues();
                dic["pageIndex"] = pageIndex - 1;
                var prevLink = htmlHelper.ActionLink("« Prev", actionName, dic);
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
                var dic = request.QueryString.ToRouteValues();
                dic["pageIndex"] = pageIndex + 1;
                var nextLink = htmlHelper.ActionLink("Next »", actionName, dic);
                next.InnerHtml = nextLink.ToHtmlString();
            }
            sb.AppendLine(prev.ToString());
            for (var i = tuple.Item1; i <= tuple.Item2; i++)
            {
                var li = new TagBuilder("li");
                var dic = request.QueryString.ToRouteValues();
                dic["pageIndex"] = i;
                var link = htmlHelper.ActionLink(i.ToString(), actionName, dic);
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

        public static MvcHtmlString FormLabelFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression)
        {
            return htmlHelper.LabelFor(expression, new { @class = "col-sm-2 control-label" });
        }

        public static MvcHtmlString FormTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression)
        {
            return htmlHelper.TextBoxFor(expression, new { @class = "form-control" });
        }

        public static MvcHtmlString FormTextAreaFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        {
            var dic = htmlAttributes.ToDictionary();
            dic.Add("class", "form-control");
            return htmlHelper.TextAreaFor(expression, dic);
        }

        private static Tuple<int, int> CountBeginEnd(int pageIndex, int pageCount)
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
        public static RouteValueDictionary ToRouteValues(this NameValueCollection collection)
        {
            var routeValueDictionary = new RouteValueDictionary();
            foreach (var key in collection.AllKeys)
            {
                routeValueDictionary.Add(key, collection[key]);
            }
            return routeValueDictionary;
        }

        public static IDictionary<string, object> ToDictionary(this object data)
        {
            if (data == null) return null; // Or throw an ArgumentNullException if you want

            const BindingFlags publicAttributes = BindingFlags.Public | BindingFlags.Instance;
            var dictionary = new Dictionary<string, object>();

            foreach (var property in data.GetType().GetProperties(publicAttributes))
            {
                if (property.CanRead)
                {
                    dictionary.Add(property.Name, property.GetValue(data, null));
                }
            }
            return dictionary;
        }
    }
}