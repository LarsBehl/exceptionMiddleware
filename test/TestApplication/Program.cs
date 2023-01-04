using ExceptionMiddleware.Extensions;

namespace ExceptionMiddleware.Test.Application;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers().AddExceptions().AddValidationSupport();

        var app = builder.Build();

        app.MapControllers();

        app.Run();
    }
}