namespace ExceptionMiddleware.Exceptions
{
    public class UnauthorizedException : AppException
    {
        private static readonly string DEFAULT_MESSAGE = "Unauthorized";
        private static readonly string TITLE = "Unauthorized";

        public UnauthorizedException(string detailMessage, int errorCode) : base(TITLE, detailMessage, errorCode)
        {

        }

        public UnauthorizedException(string detailMessage) : this(detailMessage, (int)ErrorCodes.Unauthorized)
        {

        }

        public UnauthorizedException() : this(DEFAULT_MESSAGE)
        {

        }
    }
}