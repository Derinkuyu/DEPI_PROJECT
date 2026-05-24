using System.Net;

namespace StuMap.BLL.Models
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string? Message { get; set; }
        public string[] Errors { get; set; } = [];

        public ApiResponse() { }

        public ApiResponse(bool success, HttpStatusCode statusCode, string? message = null, params string[] errors)
        {
            Success = success;
            StatusCode = statusCode;
            Message = message;
            Errors = errors;
        }

        // Helper methods for clean instantiations
        public static ApiResponse SuccessResult(string? message = null, HttpStatusCode statusCode = HttpStatusCode.OK)
            => new(true, statusCode, message);

        public static ApiResponse FailureResult(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest, params string[] errors)
            => new(false, statusCode, message, errors);
    }


    public class ApiResponse<T> : ApiResponse
    {
        public T? Data { get; set; }

        public ApiResponse() { }

        // Success constructor
        public ApiResponse(T data, HttpStatusCode statusCode, string? message = null)
        {
            Success = true;
            StatusCode = statusCode;
            Data = data;
            Message = message;
        }

        // Failure constructor
        public ApiResponse(string message, HttpStatusCode statusCode, params string[] errors)
        {
            Success = false;
            StatusCode = statusCode;
            Data = default;
            Message = message;
            Errors = errors;
        }

        // Helper methods
        public static ApiResponse<T> SuccessResult(T data, HttpStatusCode statusCode = HttpStatusCode.OK, string? message = null)
            => new(data, statusCode, message);

        public static new ApiResponse<T> FailureResult(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest, params string[] errors)
            => new(message, statusCode, errors);

    }
}
