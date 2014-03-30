
using System.Web.Mvc;

namespace FlappyBlog.Mvc.Html.Bootstrap.Btn
{
    public class Button
    {
        public Button()
        {
            Type = ButtonType.Default;
            Size=ButtonSize.Default;
            IsBlock = false;
            IsActive = false;
        }

        public ButtonType Type { get; set; }
        public ButtonSize Size { get; set; }
        public bool IsBlock { get; set; }
        public bool IsActive { get; set; }
        public string Text { get; set; }

        public MvcHtmlString Render()
        {
            var tagBuilder = new TagBuilder("button");
            tagBuilder.AddCssClass(string.Format("btn-{0}", Type.ToString().ToLower()));
            if (Size == ButtonSize.Large)
            {
                tagBuilder.AddCssClass("btn-lg");                
            }
            if (Size == ButtonSize.Small)
            {
                tagBuilder.AddCssClass("btn-sm");
            }
            if (Size == ButtonSize.ExtraSmall)
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