using Microsoft.AspNetCore.Mvc;

namespace ExceptionMiddleware.Exceptions;

/// <summary>
/// Exception which is transformed to a BadRequestResponse by the <see cref="ExceptionFilter"/>
/// </summary>
public class BadRequestException : AppException
{
    private static readonly string DEFAULT_MESSAGE = "BadRequest";
    private static readonly string TITLE = "Bad Request";

    public override IActionResult ResponseObject => new BadRequestObjectResult(this.GetErrorObject());

    /// <summary>
    /// Constructor accepting a detailed error description and custom error code
    /// </summary>
    /// <param name="detailMessage">A detailed message describing the error</param>
    /// <param name="errorCode">A custom error code which provides further information</param>
    public BadRequestException(string detailMessage, int errorCode) : base(TITLE, detailMessage, errorCode)
    {

    }

    /// <summary>
    /// Constructor accepting a detailed error description
    /// </summary>
    /// <param name="detailMessage">A detailed message describing the error</param>
    public BadRequestException(string detailMessage) : this(detailMessage, (int)ErrorCodes.BadRequest)
    {

    }

    /// <summary>
    /// Constructor using a default message and error code
    /// </summary>
    public BadRequestException() : this(DEFAULT_MESSAGE)
    {

    }
}
