using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionMiddleware.Extensions;

/// <summary>
/// An <see cref="ObjectResult"/> with the StatusCode <see cref="StatusCodes.Status500InternalServerError"/>
/// </summary>
public class InternalServerErrorObjectResult : ObjectResult
{
    /// <summary>
    /// Constructor accepting an <see cref="object"/> as the body of the response
    /// </summary>
    /// <param name="value">Body of the response</param>
    public InternalServerErrorObjectResult(object value) : base(value)
    {
        this.StatusCode = StatusCodes.Status500InternalServerError;
    }
}
