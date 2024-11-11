using System.Collections.Generic;

namespace MamyApp.Application.Models;

public class ErrorDetails
{
    public string Message { get; set; }
    public string Details { get; set; }
    public List<string> ValidationErrors { get; set; }

    public ErrorDetails(string message, string details = null, List<string> validationErrors = null)
    {
        Message = message;
        Details = details;
        ValidationErrors = validationErrors ?? new List<string>();
    }
}
