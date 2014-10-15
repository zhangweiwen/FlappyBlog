using System;
using System.Web;

namespace FlappyBlog.Mvc.Core
{
    public static class Extensions
    {
        public static bool IsPost(this HttpRequestBase request)
        {
            return string.Equals(request.HttpMethod, "POST", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}