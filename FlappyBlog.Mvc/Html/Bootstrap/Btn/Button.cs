
using System.Web.Mvc;

namespace FlappyBlog.Mvc.Html.Bootstrap.Btn
{
    public class Button
    {
        public Button()
        {
            Type = BtnType.Default;
            Size=BtnSize.Default;
            IsBlock = false;
            IsActive = false;
        }

        public BtnType Type { get; set; }
        public BtnSize Size { get; set; }
        public bool IsBlock { get; set; }
        public bool IsActive { get; set; }
        public string Text { get; set; }

        public MvcHtmlString Render()
        {
            var tagBuilder = new TagBuilder("button");
            tagBuilder.AddCssClass(string.Format("btn-{0}", Type.ToString().ToLower()));
            if (Size == BtnSize.Large)
            {
                tagBuilder.AddCssClass("btn-lg");                
            }
            if (Size == BtnSize.Small)
            {
                tagBuilder.AddCssClass("btn-sm");
            }
            if (Size == BtnSize.ExtraSmall)
            {
                tagBuilder.AddCssClass("btn-xs");
            }
            if (IsBlock)
            {
                tagBuilder.AddCssClass("btn-block");                
            }
            if (IsActive)
            {
                tagBuilder.AddCssClass("active");
            }
            tagBuilder.AddCssClass("btn");
            tagBuilder.SetInnerText(Text);
            return new MvcHtmlString(tagBuilder.ToString(TagRenderMode.Normal));
        }
    }
}