using System;
using Newtonsoft.Json;

namespace FlappyBlog.Infrastructure.Paged
{
    [Serializable]
    public class OrderInfo
    {
        public bool IsDesc { get; set; }

        public string PropertyName { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}