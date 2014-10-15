using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace FlappyBlog.Mvc.Html
{
    public class Tag<T> where T : class
    {
        protected TagBuilder TagBuilder { get; private set; }

        protected Tag(string tagName)
        {
            if (tagName.IsNullOrWhiteSpace())
                throw new ArgumentNullException("tagName");

            TagBuilder = new TagBuilder(tagName);
        }

        public T AddCssClass(string value)
        {
            if (value.IsNullOrWhiteSpace() == false)
            {
                TagBuilder.AddCssClass(value);
            }
            return this as T;
        }

        public T MergeAttribute(string key, string value)
        {
            TagBuilder.MergeAttribute(key, value);
            return this as T;
        }

        public T MergeAttributes<TKey, TValue>(IDictionary<TKey, TValue> attributes)
        {
            TagBuilder.MergeAttributes(attributes);
            return this as T;
        }

        public T SetInnerText(string innerText)
        {
            TagBuilder.SetInnerText(innerText);
            return this as T;
        }

        public T SetId(string value)
        {
            TagBuilder.MergeAttribute("id", value);
            return this as T;
        }

        public string TagName { get { return TagBuilder.TagName; } }

        public string InnerHtml
        {
            get
            {
                return TagBuilder.InnerHtml;
            }
            set
            {
                TagBuilder.InnerHtml = value;
            }
        }

        public IDictionary<string, string> Attributes
        {
            get
            {
                return TagBuilder.Attributes;
            }
        }

        public override string ToString()
        {
            return TagBuilder.ToString(TagRenderMode.Normal);
        }

        public virtual MvcHtmlString Render()
        {
            return new MvcHtmlString(ToString());
        }
    }
}