using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Threading.Tasks;

namespace eCommerce.eCommerce.API.middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                // Before the request
                var stopwatch = Stopwatch.StartNew();
                await _next(context); // Calling the next middleware in the pipeline
                stopwatch.Stop();

                // After the request
                Console.WriteLine($"Request processed in {stopwatch.ElapsedMilliseconds} ms");
            }
            catch (System.Exception ex)
            {
                // Handle the exception
                _logger.LogError($"An error occurred: {ex.GetType().ToString()} : { ex.Message }");

                if(ex.InnerException is not null) {
                    _logger.LogError($"Inner exception: {ex.InnerException.GetType().ToString()} : { ex.InnerException.Message }");
                }
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("An error occurred");
            }
        }
    }

    // Extension method to add middleware easily
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}