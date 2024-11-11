using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using MamyApp.Application.Models;
using MamyApp.Application.Enums;

namespace MamyApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        protected string UserId
        {
            get
            {
                var userIdClaim = User?.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userIdClaim))
                {
                    throw new UnauthorizedAccessException("User ID is missing from JWT.");
                }
                return userIdClaim;
            }
        }

        protected string UserRole
        {
            get
            {
                var userRoleClaim = User?.FindFirstValue(ClaimTypes.Role);
                return userRoleClaim ?? string.Empty;
            }
        }

        // Success response helper metodu
        protected IActionResult SuccessResponse<T>(T data, string message = "Success")
        {
            return Ok(ApiResponse<T>.Success(data, message));
        }

        // Failure response helper metodu
        protected IActionResult FailureResponse(string message, HttpStatusCode statusCode, List<string> errors = null)
        {
            return StatusCode((int)statusCode, ApiResponse<ErrorDetails>.Failure(message, statusCode, errors));
        }
    }
}
