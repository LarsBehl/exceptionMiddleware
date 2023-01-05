using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionMiddleware.Extensions;

/// <summary>
/// An <see cref="ObjectResult"/> with StatusCode <see cref="StatusCodes.Status501NotImplemented"/>
/// </summary>
public class NotImplementedObjectResult : ObjectResult
{
    /// <summary>
    /// Constructor accepting an <see cref="object"/> as the body of the response
    /// </summary>
    /// <param name="value">Body of the response</param>
    public NotImplementedObjectResult(object value) : base(value)
    {
        this.StatusCode = StatusCodes.Status501NotImplemented;
    }
}
