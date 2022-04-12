using Microsoft.Extensions.DependencyInjection;

namespace ExceptionMiddleware.Extensions;

public static class ServiceCollectionExtensions
{
    public static IMvcBuilder AddControllersWithExceptions(this IServiceCollection services)
    {
        return services.AddControllers(options => options.Filters.Add(new ExceptionFilter()));
    }

    public static IMvcBuilder AddExceptions(this IMvcBuilder builder)
    {
        return builder.AddMvcOptions(options => options.Filters.Add(new ExceptionFilter()));
    }
}
