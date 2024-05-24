using EldenLabs.Application.Core.Dto;
using System.Net;
using System.Text.Json;

namespace EldenLabs.Presentation.Api.Middleware.CustomMiddleware
{
    public class GlobalErrorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalErrorMiddleware> _logger;

        public GlobalErrorMiddleware(RequestDelegate next, ILogger<GlobalErrorMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception has occurred.");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new BaseResponse<string>
            {
                Data = null,
                StatusCode = (HttpStatusCode)context.Response.StatusCode,
                Message = exception.Message
            };

            var jsonResponse = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(jsonResponse);
        }
    }
}
