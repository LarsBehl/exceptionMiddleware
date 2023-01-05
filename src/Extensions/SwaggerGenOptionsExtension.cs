using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;
using ExceptionMiddleware.Model;
using ExceptionMiddleware.Exceptions;

namespace ExceptionMiddleware.Extensions;

public static class SwaggerGenOptionsExtension
{
    /// <summary>
    /// Adds the <see cref="ErrorResponse"/> and <see cref="ErrorCodes"/> to the gerated OpenAPI specification
    /// </summary>
    public static void AddExceptions(this SwaggerGenOptions options)
    {
        options.DocumentFilter<ExceptionDocumentFilter>();
    }
}
