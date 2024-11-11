using MamyApp.Application.Enums;


namespace MamyApp.Application.Models
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }

        public ApiResponse(T data, HttpStatusCode statusCode, string message)
        {
            Data = data;
            StatusCode = statusCode;
            Message = message;
        }

        public ApiResponse(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public static ApiResponse<T> Success(T data, string message = "Success")
        {
            return new ApiResponse<T>(data, HttpStatusCode.Success, message);
        }

        public static ApiResponse<ErrorDetails> Failure(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError, List<string> errors = null)
        {
            return new ApiResponse<ErrorDetails>(
                new ErrorDetails(message, null, errors),
                statusCode,
                "An error occurred");
        }
    }
}
