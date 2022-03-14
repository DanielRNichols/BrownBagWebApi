using System.Text.Json;

namespace NET6.WebApi.Middleware
{

    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Details { get; set; } = string.Empty;
        public string TraceId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }

    public class CustomExceptionHandler
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger<CustomExceptionHandler> _logger;

        public CustomExceptionHandler(RequestDelegate requestDelegate, 
            ILogger<CustomExceptionHandler> logger)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;

                var errorDetails = new ErrorDetails
                {
                    StatusCode = 500,
                    Details = ex.Message,
                    TraceId = context.TraceIdentifier,
                    UserName = context.User.Identity?.Name ?? ""

                };
                _logger.LogError("Server Error {details}", JsonSerializer.Serialize(errorDetails));

                await context.Response.WriteAsJsonAsync<ErrorDetails>(errorDetails);
            }
        }
    }
}