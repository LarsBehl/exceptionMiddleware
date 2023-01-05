using ExceptionMiddleware.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionMiddleware.Exceptions;

/// <summary>
/// Exception which is transformed to an InternalServerErrorResponse by the <see cref="ExceptionFilter"/>
/// </summary>
public class InternalServerErrorException : AppException
{
    private static readonly string TITLE = "Internal Server Error";
    private static readonly string DEFAULT_MESSAGE = "An unexpected Error occured";

    public override IActionResult ResponseObject => new InternalServerErrorObjectResult(this.GetErrorObject());

    /// <summary>
    /// Constructor accepting a detailed error description and custom error code
    /// </summary>
    /// <param name="detailMessage">A detailed message describing the error</param>
    /// <param name="errorCode">A custom error code which provides further information</param>
    public InternalServerErrorException(string detailMessage, int errorCode) : base(TITLE, detailMessage, errorCode)
    {

    }

    /// <summary>
    /// Constructor accepting a detailed error description
    /// </summary>
    /// <param name="detailMessage">A detailed message describing the error</param>
    public InternalServerErrorException(string detailMessage) : this(detailMessage, (int)ErrorCodes.InternalServerError)
    {

    }

    /// <summary>
    /// Constructor using a default message and error code
    /// <summary>
    public InternalServerErrorException() : this(DEFAULT_MESSAGE)
    {

    }
}
