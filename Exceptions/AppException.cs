using System;

namespace ExceptionMiddleware.Exceptions
{
    public class AppException : Exception
    {
        public int ErrorCode { get; set; }

        public string DetailMessage { get; set; }

        public AppException(string detailMessage, int errorCode) : base($"{detailMessage};{Environment.NewLine}ErrorCode: {errorCode.ToString()};")
        {
            this.DetailMessage = detailMessage;
            this.ErrorCode = errorCode;
        }
    }
}