using System.Net;
using FluentValidation;
using InteractiveMap.Application.Common.Exceptions;

namespace InteractiveMap.Web.Middlewares.ExceptionHandlerMiddleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;

            int code;
            switch (exception)
            {
                case ValidationException validationException:
                    code = (int)HttpStatusCode.BadRequest;
                    await response.WriteAsJsonAsync(validationException.Errors);
                    break;
                case NotFoundException notFoundException:
                    code = (int)HttpStatusCode.NotFound;
                    await response.WriteAsJsonAsync(notFoundException.Message);
                    break;
                case ForbiddenException forbiddenException:
                    code = (int)HttpStatusCode.Forbidden;
                    await response.WriteAsJsonAsync(forbiddenException.Message);
                    break;
                default:
                    code = (int)HttpStatusCode.InternalServerError;
                    await response.WriteAsJsonAsync(exception.Message);
                    break;
            }

            response.StatusCode = code;
        }
    }
}
