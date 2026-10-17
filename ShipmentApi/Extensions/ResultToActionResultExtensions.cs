using Applcation.Comman;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace ShipmentApi.Extensions
{
    public static class ResultToActionResultExtensions
    {
        public static IActionResult ToActionResult(this ControllerBase controller,  Result result)
        {
            if (result.IsSuccess)
            {
                return controller.Ok(new { message = result.Message });
            }
           return controller.StatusCode(GetStatusCode(result.ErrorType), new { message = result.Message });

        }





        public static IActionResult ToActionResult<T>(this ControllerBase controller, Result<T> result)
        {
            if (result.IsSuccess)
            {
                return controller.Ok(new { message = result.Message });
            }
            return controller.StatusCode(GetStatusCode(result.ErrorType), new { message = result.Message });

        }









        private static int GetStatusCode(ErrorType errorType)
        {
            return errorType switch
            {
                ErrorType.validation =>StatusCodes.Status400BadRequest, // Bad Request
                ErrorType.notfound => StatusCodes.Status404NotFound, // Not Found
                ErrorType.forbidden => StatusCodes.Status403Forbidden, // Forbidden
                ErrorType.conflict => StatusCodes.Status409Conflict, // Conflict
                ErrorType.unauthorized => StatusCodes.Status401Unauthorized, // Unauthorized
                ErrorType.failure => StatusCodes.Status500InternalServerError, // Internal Server Error
                _ => StatusCodes.Status500InternalServerError, // Default to Internal Server Error for unknown error types
            };
        }
    }
}
