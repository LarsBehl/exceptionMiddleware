using System.Reflection;
using ExceptionMiddleware.Extensions;
using Microsoft.OpenApi.Models;

namespace ExceptionMiddleware.Test.Application;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers().AddExceptions().AddValidationSupport();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Test Application",
                Description = "A test application"
            });

            options.AddExceptions();
        });

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        });

        app.MapControllers();

        app.Run();
    }
}