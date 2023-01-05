using System.Text;
using ExceptionMiddleware.Exceptions;
using ExceptionMiddleware.Model;
using Microsoft.Extensions.DependencyInjection;

namespace ExceptionMiddleware.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add support for MVC controllers, the ExceptionMiddleware and custom exceptions for validation errors to the <see cref="IServiceCollection"/> of the application
    /// </summary>
    /// <returns>An <see cref="IMvcBuilder"/> that can be used to further configure the MVC services</returns>
    public static IMvcBuilder AddControllersWithExceptions(this IServiceCollection services)
    {
        return services.AddControllers()
                       .AddExceptions()
                       .AddValidationSupport();
    }

    /// <summary>
    /// Enables the ExceptionMiddleware
    /// </summary>
    /// <returns>An <see cref="IMvcBuilder"/> that can be used to further configure the MVC services</returns>
    public static IMvcBuilder AddExceptions(this IMvcBuilder builder)
    {
        return builder.AddMvcOptions(options => options.Filters.Add(new ExceptionFilter()));
    }

    /// <summary>
    /// Enables that an <see cref="ErrorResponse"/> is returned as the result of an validation error
    /// </summary>
    /// <returns>An <see cref="IMvcBuilder"/> that can be used to further configure the MVC services</returns>
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
