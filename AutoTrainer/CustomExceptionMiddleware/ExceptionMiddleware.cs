using AutoTrainerServices.Services.Exeptions;
using System.Net;

namespace AutoTrainer.CustomExceptionMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;       

        public ExceptionMiddleware(RequestDelegate next)
        {            
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {                
                await HandleExceptionAsync(httpContext, ex);
            }
            
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var statusCode = exception switch
            {
                NotFoundExeption => 404,
                _ => 500
            };
            context.Response.StatusCode = statusCode;

            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = statusCode,
                Message = exception.Message
            }.ToString());
        }
    }
}
