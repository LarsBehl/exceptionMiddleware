using ExceptionMiddleware.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionMiddleware.Exceptions;

/// <summary>
/// Exception which is transformed to a ForbiddenResponse by the <see cref="ExceptionFilter"/>
/// </summary>
public class ForbiddenException : AppException
{
    private static readonly string TITLE = "Forbidden";
    private static readonly string DEFAULT_MESSAGE = "Forbidden to access resource";

    public override IActionResult ResponseObject => new ForbiddenObjectResult(this.GetErrorObject());

    /// <summary>
    /// Constructor accepting a detailed error description and custom error code
    /// </summary>
    /// <param name="detailMessage">A detailed message describing the error</param>
    /// <param name="errorCode">A custom error code which provides further information</param>
    public ForbiddenException(string detailMessage, int errorCode) : base(TITLE, detailMessage, errorCode)
    {

    }

    /// <summary>
    /// Constructor accepting a detailed error description
    /// </summary>
    /// <param name="detailMessage">A detailed message describing the rror</param>
    public ForbiddenException(string detailMessage) : this(detailMessage, (int)ErrorCodes.Forbidden)
    {

    }

    /// <summary>
    /// Constructor using a default message and error code
    /// </summary>
    public ForbiddenException() : this(DEFAULT_MESSAGE)
    {

    }
}
