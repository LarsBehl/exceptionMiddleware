namespace ExceptionMiddleware.Exceptions
{
    public class UnauthorizedException : AppException
    {
        private static readonly string DEFAULT_MESSAGE = "Unauthorized";

        public UnauthorizedException(string detailMessage, int errorCode) : base(detailMessage, errorCode)
        {

        }

        public UnauthorizedException(string detailMessage) : this(detailMessage, (int) ErrorCodes.Unauthorized)
        {

        }

        public UnauthorizedException() : this(DEFAULT_MESSAGE)
        {
            
        }
    }
}