using Microsoft.AspNetCore.Mvc;

namespace ExceptionMiddleware.Exceptions;

/// <summary>
/// Exception which is transofrmed to a ConflictResponse by the <see cref="ExceptionFilter"/>
/// </summary>
public class ConflictException : AppException<ConflictObjectResult>
{
    private static readonly string DEFAULT_MESSAGE = "Conflict";
    private static readonly string TITLE = "Conflict";

    /// <summary>
    /// Constructor accepting a detailed error description and custom error code
    /// </summary>
    /// <param name="detailMessage">A detailed message describing the error</param>
    /// <param name="errorCode">A custom error code which provides further information</param>
    public ConflictException(string detailMessage, int errorCode) : base(TITLE, detailMessage, errorCode)
    {

    }

    /// <summary>
    /// Constructor accepting a detailed error description
    /// </summary>
    /// <param name="detailMessage">A detailed messahe describing the error</param>
    public ConflictException(string detailMessage) : this(detailMessage, (int)ErrorCodes.Conflict)
    {

    }

    /// <summary>
    /// Constructor using a default message and error code
    /// </summary>
    public ConflictException() : this(DEFAULT_MESSAGE)
    {

    }
}
