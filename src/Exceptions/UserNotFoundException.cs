namespace ExceptionMiddleware.Exceptions;

public class UserNotFoundException : NotFoundException
{
    private static readonly string DEFAULT_MESSAGE = "User not found";

    public UserNotFoundException(string detailMessage, int errorCode) : base(detailMessage, errorCode)
    {

    }

    public UserNotFoundException(string detailMessage) : this(detailMessage, (int)ErrorCodes.UserNotFound)
    {

    }

    public UserNotFoundException() : this(DEFAULT_MESSAGE)
    {

    }
}
