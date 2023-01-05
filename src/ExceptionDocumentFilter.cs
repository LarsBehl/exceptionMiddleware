using ExceptionMiddleware.Exceptions;
using ExceptionMiddleware.Model;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ExceptionMiddleware;

internal class ExceptionDocumentFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        context.SchemaGenerator.GenerateSchema(typeof(ErrorResponse), context.SchemaRepository);
        context.SchemaGenerator.GenerateSchema(typeof(ErrorCodes), context.SchemaRepository);
    }
}
