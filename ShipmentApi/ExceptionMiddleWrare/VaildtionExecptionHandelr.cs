using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

namespace ShipmentApi.ExceptionMiddleWrare
{
    public sealed class VaildtionExecptionHandelr(IProblemDetailsService problemDetailsService, ILogger<VaildtionExecptionHandelr> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not ValidationException validationException)
            {
                return false;
            }

            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            var context = new ProblemDetailsContext
            {
                HttpContext = httpContext,
                Exception = exception,
                ProblemDetails = new ProblemDetails
                {
                    Type = exception.GetType().Name,
                    Status = httpContext.Response.StatusCode,
                    Title = "Validation error occurred",
                    Detail = validationException.Message
                }
            };

            var errors = validationException.Errors.GroupBy(e => e.PropertyName)
                .ToDictionary(g => g.Key.ToLowerInvariant(), g => g.Select(e => e.ErrorMessage).ToArray());
           context.ProblemDetails.Extensions.Add("errors", errors);
            
            return await problemDetailsService.TryWriteAsync(context);
        }
    }
}
