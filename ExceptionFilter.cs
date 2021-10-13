using ExceptionMiddleware.Exceptions;
using ExceptionMiddleware.Extensions;
using ExceptionMiddleware.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace ExceptionMiddleware
{
    public class ExceptionFilter : IActionFilter, IOrderedFilter
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
                ErrorResponse resultContent = e.GetErrorObject();
                IActionResult result = e switch
                {
                    BadRequestException bre => new BadRequestObjectResult(resultContent),
                    UserNotFoundException unfe => new NotFoundObjectResult(resultContent),
                    NotFoundException nfe => new NotFoundObjectResult(resultContent),
                    UnauthorizedException uae => new UnauthorizedObjectResult(resultContent),
                    _ => new InternalServerErrorObjectResult(resultContent)
                };
                context.Result = result;
                context.ExceptionHandled = true;
                return;
            }

            if(context.Exception is not null && !context.ExceptionHandled)
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
}