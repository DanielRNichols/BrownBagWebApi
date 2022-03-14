using NET6.WebApi.Middleware;

namespace NET6.WebApi.Extensions
{
    public static class MiddlewareExtensions
    {
        public static void UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<CustomExceptionHandler>();
        }
    }
}