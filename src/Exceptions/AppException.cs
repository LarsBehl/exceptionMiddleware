using ExceptionMiddleware.Model;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionMiddleware.Exceptions;

/// <summary>
/// <see langword="abstract"/> base class of all custom exceptions caught by the <see cref="ExceptionFilter"/>
/// </summary>
public abstract class AppException : Exception
{
    /// <summary>
    /// Title of the exception
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Custom error code providing additional information
    /// </summary>
    public int ErrorCode { get; set; }

    /// <summary>
    /// A detailed description of the error
    /// </summary>
    public string DetailMessage { get; set; }

    /// <summary>
    /// An <see langword="abstract"/> property which calculates the response object sent to the requesting client
    /// </summary>
    public abstract IActionResult ResponseObject { get; }

    public AppException(string title, string detailMessage, int errorCode) : base(detailMessage)
    {
        this.DetailMessage = detailMessage;
        this.ErrorCode = errorCode;
        this.Title = title;
    }

    /// <summary>
    /// A method constructing the <see cref="ErrorResponse"/> object provided to the requesting client
    /// </summary>
    /// <returns>An <see cref="ErrorResponse"/> object representing the encountered issue</returns>
    protected ErrorResponse GetErrorObject()
    {
        return new ErrorResponse()
        {
            Title = this.Title,
            DetailMessage = this.DetailMessage,
            ErrorCode = this.ErrorCode
        };
    }
}
