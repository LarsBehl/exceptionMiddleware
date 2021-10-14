using System;
using ExceptionMiddleware.Model;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionMiddleware.Exceptions
{
    public abstract class AppException : Exception
    {
        public string Title { get; set; }

        public int ErrorCode { get; set; }

        public string DetailMessage { get; set; }

        public abstract IActionResult ResponseObject { get; }

        public AppException(string title, string detailMessage, int errorCode) : base(detailMessage)
        {
            this.DetailMessage = detailMessage;
            this.ErrorCode = errorCode;
            this.Title = title;
        }

        protected ErrorResponse GetErrorObject()
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