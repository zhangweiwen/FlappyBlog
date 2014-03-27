using System;
using System.Collections.Generic;

namespace FlappyBlog.Application.Responses
{
    [Serializable]
    public abstract class BaseResponse
    {
        public bool Success { get; set; }

        public List<string> Messages { get; set; }
    }
}