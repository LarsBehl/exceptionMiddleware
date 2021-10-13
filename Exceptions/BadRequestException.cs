namespace ExceptionMiddleware.Exceptions
{
    public class BadRequestException : AppException
    {
        private static readonly string DEFAULT_MESSAGE = "BadRequest";
        private static readonly string TITLE = "Bad Request";

        public BadRequestException(string detailMessage, int errorCode) : base(TITLE, detailMessage, errorCode)
        {

        }

        public BadRequestException(string detailMessage) : this(detailMessage, (int) ErrorCodes.BadRequest)
        {

        }

        public BadRequestException(): this(DEFAULT_MESSAGE)
        {

        }
    }
}