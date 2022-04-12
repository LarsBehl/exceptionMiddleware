using ExceptionMiddleware.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionMiddleware.Exceptions;

public class InternalServerErrorException : AppException
{
    private static readonly string TITLE = "Internal Server Error";
    private static readonly string DEFAULT_MESSAGE = "An unexpected Error occured";

    public override IActionResult ResponseObject => new InternalServerErrorObjectResult(this.GetErrorObject());

    public InternalServerErrorException(string detailMessage, int errorCode) : base(TITLE, detailMessage, errorCode)
    {

    }

    public InternalServerErrorException(string detailMessage) : this(detailMessage, (int)ErrorCodes.InternalServerError)
    {

    }

    public InternalServerErrorException() : this(DEFAULT_MESSAGE)
    {

    }
}
