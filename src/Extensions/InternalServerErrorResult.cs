using ExceptionMiddleware.Exceptions;
using ExceptionMiddleware.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionMiddleware.Extensions;

public class InternalServerErrorResult : ObjectResult
{
    public InternalServerErrorResult() : this(GetDefaultError())
    {

    }

    public InternalServerErrorResult(object value) : base(value)
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