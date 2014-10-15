using System;

namespace FlappyBlog.Infrastructure.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message)
            : base(message)
        {

        }

        public override string ToString()
        {
            const string format = "Type => {0}, Message => {1}";
            return string.Format(format, GetType().Name, Message);
        }
    }
}