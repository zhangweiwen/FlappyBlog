using System;

namespace FlappyBlog.Infrastructure.Paged
{
    [Serializable]
    public class OrderInfo
    {
        public bool IsDesc { get; set; }

        public string PropertyName { get; set; }
    }
}