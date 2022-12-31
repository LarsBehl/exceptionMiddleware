using System.Text;
using ExceptionMiddleware.Exceptions;
using Microsoft.Extensions.DependencyInjection;

namespace ExceptionMiddleware.Extensions;

public static class ServiceCollectionExtensions
{
    public static IMvcBuilder AddControllersWithExceptions(this IServiceCollection services)
    {
        return services.AddControllers()
                       .AddExceptions()
                       .AddValidationSupport();
    }

    public static IMvcBuilder AddExceptions(this IMvcBuilder builder)
    {
        return builder.AddMvcOptions(options => options.Filters.Add(new ExceptionFilter()));
    }

    public static IMvcBuilder AddValidationSupport(this IMvcBuilder builder)
    {
        return builder.ConfigureApiBehaviorOptions(options =>
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                StringBuilder bob = new StringBuilder();
                bool isFirst = true;

                foreach (var modelState in context.ModelState.Values)
                {
                    if (modelState.Errors.Count > 0)
                    {
                        foreach (var error in modelState.Errors)
                        {
                            if (isFirst)
                            {
                                bob.Append(error.ErrorMessage);
                                isFirst = false;
                            }
                            else
                                bob.Append($", {error.ErrorMessage}");
                        }
                    }
                }

                return new BadRequestException(bob.ToString()).ResponseObject;
            };
        });
    }
}
