using ExceptionMiddleware.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionMiddleware.Exceptions;

/// <summary>
/// Exception which is tranformed to a NotImplementedResponse by the <see cref="ExceptionFilter"/>
/// </summary>
/// <remarks>
/// Instead of using this exception one can also use the <see cref="NotImplementedException"/>
/// as they are also converted to a <see cref="NotImplementedObjectResult"/>
/// </remarks>
public class NotImplementedErrorException : AppException<NotImplementedObjectResult>
{
    private static readonly string DEFAULT_MESSAGE = "NotImplemented";
    private static readonly string TITLE = "Not Implemented";

    /// <summary>
    /// Constructor accepting a detailed error description and custom error code
    /// </summary>
    /// <param name="detailMessage">A detailed message describing the error</param>
    /// <param name="errorCode">A custom error code which provides further information</param>
    public NotImplementedErrorException(string detailMessage, int errorCode) : base(TITLE, detailMessage, errorCode)
    {

    }

    /// <summary>
    /// Constructor accepting a detailed error description
    /// </summary>
    /// <param name="detailMessage">A detailed message describing the error</param>
    public NotImplementedErrorException(string detailMessage) : this(detailMessage, (int)ErrorCodes.NotImplemented)
    {

    }

    /// <summary>
    /// Constructor using a default message and error code
    /// </summary>
    public NotImplementedErrorException() : this(DEFAULT_MESSAGE)
    {

    }
}
