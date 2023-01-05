using Microsoft.AspNetCore.Mvc;

namespace ExceptionMiddleware.Exceptions;

/// <summary>
/// Exception which is transformed to a UnauthorizedResponse by the <see cref="ExceptionFilter"/>
/// </summary>
public class UnauthorizedException : AppException
{
    private static readonly string DEFAULT_MESSAGE = "Unauthorized";
    private static readonly string TITLE = "Unauthorized";

    public override IActionResult ResponseObject => new UnauthorizedObjectResult(this.GetErrorObject());

    /// <summary>
    /// Constructor accepting a detailed error description and custom error code
    /// </summary>
    /// <param name="detailMessage">A detailed message describing the error</param>
    /// <param name="errorCode">A custom error code which provides further information</param>
    public UnauthorizedException(string detailMessage, int errorCode) : base(TITLE, detailMessage, errorCode)
    {

    }

    /// <summary>
    /// Constructor accepting a detailed error description
    /// </summary>
    /// <param name="detailMessage">A detailed message describing the error</param>
    public UnauthorizedException(string detailMessage) : this(detailMessage, (int)ErrorCodes.Unauthorized)
    {

    }

    /// <summary>
    /// Constructor using a detfault message and error code
    /// </summary>
    public UnauthorizedException() : this(DEFAULT_MESSAGE)
    {

    }
}
