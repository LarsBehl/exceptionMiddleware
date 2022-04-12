using ExceptionMiddleware.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionMiddleware.Exceptions;

public class NotImplementedErrorException : AppException
{
    private static readonly string DEFAULT_MESSAGE = "NotImplemented";
    private static readonly string TITLE = "Not Implemented";

    public override IActionResult ResponseObject => new NotImplementedObjectResult(this.GetErrorObject());

    public NotImplementedErrorException(string detailMessage, int errorCode) : base(TITLE, detailMessage, errorCode)
    {

    }

    public NotImplementedErrorException(string detailMessage) : this(detailMessage, (int)ErrorCodes.NotImplemented)
    {

    }

    public NotImplementedErrorException() : this(DEFAULT_MESSAGE)
    {

    }
}
