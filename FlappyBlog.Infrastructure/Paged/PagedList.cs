using System;
using System.Collections.Generic;

namespace FlappyBlog.Infrastructure.Paged
{
    [Serializable]
    public class PagedList<T>
    {
        public PagedList()
        {

        }

        public PagedList(int pageSize, int totalCount)
        {
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPage = (TotalCount + PageSize - 1) / PageSize;
        }

        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public int TotalCount { get; set; }

        public int TotalPage { get; set; }

        public List<T> Items { get; set; }
    }
}