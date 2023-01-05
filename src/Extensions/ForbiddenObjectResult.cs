using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionMiddleware.Extensions;

/// <summary>
/// An extension to the present <see cref="ForbidResult"/> which has support for custom content
/// </summary>
public class ForbiddenObjectResult : ObjectResult
{
    /// <summary>
    /// Constructor accepting an <see cref="object"/> as the body of the response
    /// </summary>
    /// <param name="value">Body of the response</param>
    public ForbiddenObjectResult(object value) : base(value)
    {
        this.StatusCode = StatusCodes.Status403Forbidden;
    }
}
