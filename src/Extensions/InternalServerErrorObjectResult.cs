using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionMiddleware.Extensions;

public class InternalServerErrorObjectResult : ObjectResult
{
    public InternalServerErrorObjectResult(object value) : base(value)
    {
        this.StatusCode = StatusCodes.Status500InternalServerError;
    }
}
