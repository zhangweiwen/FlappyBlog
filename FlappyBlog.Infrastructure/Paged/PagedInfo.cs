using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FlappyBlog.Infrastructure.Paged
{
    [Serializable]
    public class PagedInfo
    {

        public PagedInfo()
        {
            OrderInfos = new List<OrderInfo>
            {
                new OrderInfo {PropertyName = "UpdatedDate", IsDesc = true}
            };
        }

        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public IList<OrderInfo> OrderInfos { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}