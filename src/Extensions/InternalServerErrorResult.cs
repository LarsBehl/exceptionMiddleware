using ExceptionMiddleware.Exceptions;
using ExceptionMiddleware.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionMiddleware.Extensions;

/// <summary>
/// An <see cref="ObjectResult"/> with the StatusCode <see cref="StatusCodes.Status500InternalServerError"/>
/// and a default body
/// </summary>
public class InternalServerErrorResult : ObjectResult
{
    /// <summary>
    /// Constructor for creating an <see cref="InternalServerErrorResult"/> with a default body
    /// </summary>
    public InternalServerErrorResult() : this(GetDefaultError())
    {

    }

    private InternalServerErrorResult(object value) : base(value)
    {
        this.StatusCode = StatusCodes.Status500InternalServerError;
    }

    private static ErrorResponse GetDefaultError()
    {
        return new ErrorResponse()
        {
            Title = "Internal Server Error",
            DetailMessage = "An unknown error occured",
            ErrorCode = (int)ErrorCodes.InternalServerError
        };
    }
}