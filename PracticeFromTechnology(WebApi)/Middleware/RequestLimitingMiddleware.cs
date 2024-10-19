using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;

namespace PracticeFromTechnology_WebApi_.Middleware
{
    public class RequestLimitingMiddleware
    {
        private static int _currentRequest = 0;
        private readonly RequestDelegate _next;
        private readonly int _parallelLimit;

        public RequestLimitingMiddleware(RequestDelegate next, IOptions<Settings> options)
        {
            _next = next;
            _parallelLimit = options.Value.ParallelLimit;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var current = Interlocked.Increment(ref _currentRequest);

            Console.WriteLine($"Current request count: {current}, Parallel limit: {_parallelLimit}");

            if (current > _parallelLimit)
            {
                Interlocked.Decrement(ref _currentRequest);

                context.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                await context.Response.WriteAsync("Service unavailable. To many request");
                return;
            }

            await _next(context);
        }
    }
}
