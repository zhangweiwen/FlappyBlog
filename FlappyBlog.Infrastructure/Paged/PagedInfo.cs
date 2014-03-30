using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FlappyBlog.Infrastructure.Paged
{
    [Serializable]
    public class PagedInfo
    {
        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public IList<OrderInfo> OrderInfos { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}