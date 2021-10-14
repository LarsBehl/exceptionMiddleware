using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ExceptionMiddleware.Extensions
{
    public static class SwaggerGenOptionsExtension
    {
        public static void AddExceptions(this SwaggerGenOptions options)
        {
            options.DocumentFilter<ExceptionDocumentFilter>();
        }
    }
}