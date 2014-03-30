using System;
using System.Web.Mvc;

namespace FlappyBlog.Mvc.Html.Bootstrap
{
    public class Table : IDisposable
    {
        private TagBuilder _divBuilder;
        private TagBuilder _tableBuilder;
        private readonly ViewContext _viewContext;

        public Table(ViewContext viewContext)
        {
            _viewContext = viewContext;
            CreateDiv();
            CreateTable();

            _viewContext.Writer.WriteLine(_divBuilder.ToString(TagRenderMode.StartTag));
            _viewContext.Writer.WriteLine(_tableBuilder.ToString(TagRenderMode.StartTag));
        }

        private void CreateDiv()
        {
            _divBuilder = new TagBuilder("div");
            _divBuilder.AddCssClass("table-responsive");
        }

        private void CreateTable()
        {
            _tableBuilder = new TagBuilder("table");
            _tableBuilder.AddCssClass("table-condensed");
            _tableBuilder.AddCssClass("table-hover");
            _tableBuilder.AddCssClass("table-bordered");
            _tableBuilder.AddCssClass("table-striped");
            _tableBuilder.AddCssClass("table");
        }

        public void Dispose()
        {
            _viewContext.Writer.WriteLine(_tableBuilder.ToString(TagRenderMode.EndTag));
            _viewContext.Writer.WriteLine(_divBuilder.ToString(TagRenderMode.EndTag));
        }
    }
}