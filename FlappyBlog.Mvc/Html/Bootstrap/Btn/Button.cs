using System.Web.Mvc;

namespace FlappyBlog.Mvc.Html.Bootstrap.Btn
{
    public class Button : Tag<Button>
    {
        public Button()
            : base("button")
        {
            Type = BtnType.Default;
            Size = BtnSize.Default;
            IsBlock = false;
            IsActive = false;
        }

        public BtnType Type { get; set; }
        public BtnSize Size { get; set; }
        public bool IsBlock { get; set; }
        public bool IsActive { get; set; }

        public Button SetType(BtnType type)
        {
            Type = type;
            return this;
        }

        public Button SetSize(BtnSize size)
        {
            Size = size;
            return this;
        }

        public Button SetBlock(bool isBlock)
        {
            IsBlock = isBlock;
            return this;
        }

        public Button SetActive(bool isActive)
        {
            IsActive = isActive;
            return this;
        }

        public override string ToString()
        {
            TagBuilder.AddCssClass("btn");
            RenderType();
            RenderSize();
            if (IsBlock)
            {
                TagBuilder.AddCssClass("btn-block");
            }
            if (IsActive)
            {
                TagBuilder.AddCssClass("active");
            }
            return TagBuilder.ToString(TagRenderMode.Normal);
        }

        private void RenderType()
        {
            switch (Type)
            {
                case BtnType.Danger:
                    {
                        TagBuilder.AddCssClass("btn-danger");
                        break;
                    }
                case BtnType.Default:
                    {
                        TagBuilder.AddCssClass("btn-default");
                        break;
                    }
                case BtnType.Info:
                    {
                        TagBuilder.AddCssClass("btn-info");
                        break;
                    }
                case BtnType.Link:
                    {
                        TagBuilder.AddCssClass("btn-link");
                        break;
                    }
                case BtnType.Primary:
                    {
                        TagBuilder.AddCssClass("btn-primary");
                        break;
                    }
                case BtnType.Success:
                    {
                        TagBuilder.AddCssClass("btn-success");
                        break;
                    }
                case BtnType.Warning:
                    {
                        TagBuilder.AddCssClass("btn-warning");
                        break;
                    }
            }
        }

        private void RenderSize()
        {
            switch (Size)
            {
                case BtnSize.Default:
                    {
                        break;
                    }
                case BtnSize.ExtraSmall:
                    {
                        TagBuilder.AddCssClass("btn-xs");
                        break;
                    }
                case BtnSize.Large:
                    {
                        TagBuilder.AddCssClass("btn-lg");
                        break;
                    }
                case BtnSize.Small:
                    {
                        TagBuilder.AddCssClass("btn-sm");
                        break;
                    }
            }
        }
    }
}