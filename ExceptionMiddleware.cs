using System;
using System.Threading.Tasks;
using ExceptionMiddleware.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next) => this._next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AppException e)
            {
                await this.HandleExceptionAsync(e, context);
            }
        }

        private Task HandleExceptionAsync(AppException e, HttpContext context)
        {
            ActionContext actionContext = new ActionContext()
            {
                HttpContext = context
            };

            // TODO implement
            switch(e)
            {
                default:
                    throw new ArgumentException();
            }
        }
    }
}