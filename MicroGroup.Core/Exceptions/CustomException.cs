using System.Net;

namespace MicroGroup.Core.Exceptions
{
    public class CustomException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public List<string> ErrrorList { get; set; }

        public CustomException() : base()
        {

        }

        public CustomException(string message) : base(message) { }

        public CustomException(string message, HttpStatusCode httpStatusCode) : base(message)
        {
            this.HttpStatusCode = httpStatusCode;
        }

    }
}
