using ExceptionMiddleware.Exceptions;
using ExceptionMiddleware.Model;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionMiddleware.Extensions;

public class InternalServerErrorResult : ObjectResult
{
    public InternalServerErrorResult() : base(GetDefaultError())
    {

    }

    public InternalServerErrorResult(object value) : base(value)
    {

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