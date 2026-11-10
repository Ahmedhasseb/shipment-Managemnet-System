using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ShipmentApi.ExceptionMiddleWrare
{
    public class GlobalExecptionMiddleWare(IProblemDetailsService problemDetailsService ,ILogger<GlobalExecptionMiddleWare> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            logger.LogError(exception, "An unhandled exception occurred.");
            httpContext.Response.StatusCode = exception switch
            {
                ApplicationException => StatusCodes.Status400BadRequest,
                KeyNotFoundException => StatusCodes.Status404NotFound,
                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError
            };

            return await problemDetailsService.TryWriteAsync(new ProblemDetailsContext
            {
                HttpContext = httpContext,
                Exception = exception,

                ProblemDetails = new ProblemDetails
                {
                    Type=exception.GetType().Name,
                    Status = httpContext.Response.StatusCode,
                    Title = "An error occurred",
                    Detail = exception.Message
                }
            });

        }
    }
}
