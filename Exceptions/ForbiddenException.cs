using ExceptionMiddleware.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionMiddleware.Exceptions;

public class ForbiddenException : AppException
{
    private static readonly string TITLE = "Forbidden";
    private static readonly string DEFAULT_MESSAGE = "Forbidden to access resource";
    public override IActionResult ResponseObject => new ForbiddenObjectResult(this.GetErrorObject());

    public ForbiddenException(string detailMessage, int errorCode) : base(TITLE, detailMessage, errorCode)
    {

    }

    public ForbiddenException(string detailMessage) : this(detailMessage, (int)ErrorCodes.Forbidden)
    {

    }

    public ForbiddenException() : this(DEFAULT_MESSAGE)
    {

    }
}
