namespace ExceptionMiddleware.Exceptions;

/// <summary>
/// An exception extending the <see cref="NotFoundException"/> for the special case of being unable to find a user
/// </summary>
public class UserNotFoundException : NotFoundException
{
    private static readonly string DEFAULT_MESSAGE = "User not found";

    /// <inheritdoc/>
    public UserNotFoundException(string detailMessage, int errorCode) : base(detailMessage, errorCode)
    {

    }

    /// <inheritdoc/>
    public UserNotFoundException(string detailMessage) : this(detailMessage, (int)ErrorCodes.UserNotFound)
    {

    }

    /// <inheritdoc/>
    public UserNotFoundException() : this(DEFAULT_MESSAGE)
    {

    }
}
