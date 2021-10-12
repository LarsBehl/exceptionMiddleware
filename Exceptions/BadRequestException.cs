namespace ExceptionMiddleware.Exceptions
{
    public class BadRequestException : AppException
    {
        private static readonly string DEFAULT_MESSAGE = "BadRequest";

        public BadRequestException(string detailMessage, int errorCode) : base(detailMessage, errorCode)
        {

        }

        public BadRequestException(string detailMessage) : base(detailMessage, (int) ErrorCodes.BadRequest)
        {

        }

        public BadRequestException(): this(DEFAULT_MESSAGE)
        {

        }
    }
}