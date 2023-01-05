using ExceptionMiddleware.Exceptions;
using ExceptionMiddleware.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace ExceptionMiddleware;

internal class ExceptionFilter : IActionFilter, IOrderedFilter
{
    public int Order => int.MaxValue - 10;
    private ILogger<ExceptionFilter> _logger;

    public ExceptionFilter()
    {
        this._logger = LoggerFactory.Create(b => b.AddConsole()).CreateLogger<ExceptionFilter>();
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is AppException e)
        {
            this._logger.LogInformation($"Handling exception: {e.Message}");
            context.Result = e.ResponseObject;
            context.ExceptionHandled = true;
            return;
        }

        if (context.Exception is NotImplementedException nie)
        {
            this._logger.LogInformation($"Handling System.NotImplementedException");
            NotImplementedErrorException niee = new NotImplementedErrorException(nie.Message);
            context.Result = niee.ResponseObject;
            context.ExceptionHandled = true;
            return;
        }

        if (context.Exception is not null && !context.ExceptionHandled)
        {
            this._logger.LogError("Unhandled exception; Returning InternalServerError");
            context.Result = new InternalServerErrorResult();
            context.ExceptionHandled = true;
        }
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {

    }
}
