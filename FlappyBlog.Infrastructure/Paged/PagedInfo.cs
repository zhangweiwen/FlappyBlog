using System;
using System.Collections.Generic;

namespace FlappyBlog.Infrastructure.Paged
{
    [Serializable]
    public class PagedInfo
    {
        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public IList<OrderInfo> OrderInfos { get; set; }
    }
}