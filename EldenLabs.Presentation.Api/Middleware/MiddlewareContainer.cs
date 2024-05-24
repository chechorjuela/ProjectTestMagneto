using EldenLabs.Presentation.Api.Middleware.CustomMiddleware;

namespace EldenLabs.Presentation.Api.Middleware
{
    public class MiddlewareContainer
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MiddlewareContainer> _logger;
        private readonly RequestDelegate _innerMiddlewarePipeline;

        public MiddlewareContainer(RequestDelegate next, ILogger<MiddlewareContainer> logger, IServiceProvider serviceProvider)
        {
            _next = next;
            _logger = logger;

            // setting the configuration pipeline
            var innerBuilder = new ApplicationBuilder(serviceProvider);

            // Add middleware custom create by developers
            innerBuilder.UseMiddleware<GlobalErrorMiddleware>();

            innerBuilder.Run(_next);
            _innerMiddlewarePipeline = innerBuilder.Build();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _innerMiddlewarePipeline(context);
        }
    }
}
