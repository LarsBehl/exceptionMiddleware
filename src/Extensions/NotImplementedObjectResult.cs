using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionMiddleware.Extensions;

public class NotImplementedObjectResult : ObjectResult
{
    public NotImplementedObjectResult(object value) : base(value)
    {
        this.StatusCode = StatusCodes.Status501NotImplemented;
    }
}
