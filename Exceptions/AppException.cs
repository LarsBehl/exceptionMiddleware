using System;
using ExceptionMiddleware.Model;

namespace ExceptionMiddleware.Exceptions
{
    public class AppException : Exception
    {
        public string Title { get; set; }

        public int ErrorCode { get; set; }

        public string DetailMessage { get; set; }

        public AppException(string title, string detailMessage, int errorCode) : base(detailMessage)
        {
            this.DetailMessage = detailMessage;
            this.ErrorCode = errorCode;
            this.Title = title;
        }

        public ErrorResponse GetErrorObject()
        {
            return new ErrorResponse()
            {
                Title = this.Title,
                DetailMessage = this.DetailMessage,
                ErrorCode = this.ErrorCode
            };
        }
    }
}