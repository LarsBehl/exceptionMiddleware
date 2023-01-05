using Microsoft.AspNetCore.Mvc;

namespace ExceptionMiddleware.Exceptions;

/// <summary>
/// Exception which is transformed to a NotFoundResponse by the <see cref="ExceptionFilter"/>
/// </summary>
public class NotFoundException : AppException
{
    private static readonly string DEFAULT_MESSAGE = "Ressource not found";
    private static readonly string TITLE = "Not Found";

    public override IActionResult ResponseObject => new NotFoundObjectResult(this.GetErrorObject());

    /// <summary>
    /// Constructor accepting a detailed error description and custom error code
    /// </summary>
    /// <param name="detailMessage">A detailed message describing the error</param>
    /// <param name="errorCode">A custom error code which provides further information</param>
    public NotFoundException(string detailMessage, int errorCode) : base(TITLE, detailMessage, errorCode)
    {

    }

    /// <summary>
    /// Constructor accepting a detailed error description
    /// </summary>
    /// <param name="detailMessage">A detailed message describing the error</param>
    public NotFoundException(string detailMessage) : this(detailMessage, (int)ErrorCodes.RessourceNotFound)
    {

    }

    /// <summary>
    /// Constructor using a default message and error code
    /// </summary>
    public NotFoundException() : this(DEFAULT_MESSAGE)
    {

    }
}
