namespace Elux.Domain.Responses
{
    /// <summary>
    /// Represents a base response with generic data and standard response properties.
    /// </summary>
    /// <typeparam name="T">The type of data being returned.</typeparam>
    public class BaseResponse<T> : AppResponse
    {
        /// <summary>
        /// Gets the response data.
        /// </summary>
        public T Data { get; private set; }

        /// <summary>
        /// Creates a successful response with default status and message.
        /// </summary>
        /// <returns>A successful <see cref="BaseResponse{T}"/>.</returns>
        public static BaseResponse<T> Success()
        {
            return new BaseResponse<T>()
            {
                StatusCode = "200",
                Message = "Succeeded.",
                Succeeded = true,
                //TestCommit
            };
        }

        /// <summary>
        /// Creates a successful response with a custom message.
        /// </summary>
        /// <param name="message">The success message.</param>
        /// <returns>A successful <see cref="BaseResponse{T}"/>.</returns>
        public static BaseResponse<T> Success(string message)
        {
            return new BaseResponse<T>()
            {
                StatusCode = "200",
                Succeeded = true,
                Message = message
            };
        }

        /// <summary>
        /// Creates a successful response with data and default message.
        /// </summary>
        /// <param name="data">The data to include in the response.</param>
        /// <returns>A successful <see cref="BaseResponse{T}"/>.</returns>
        public static BaseResponse<T> Success(T data)
        {
            return new BaseResponse<T>()
            {
                Data = data,
                StatusCode = "200",
                Succeeded = true,
                Message = "Succeeded."
            };
        }

        /// <summary>
        /// Creates a successful response with a custom message and data.
        /// </summary>
        /// <param name="message">The success message.</param>
        /// <param name="data">The data to include in the response.</param>
        /// <returns>A successful <see cref="BaseResponse{T}"/>.</returns>
        public static BaseResponse<T> Success(string message, T data)
        {
            return new BaseResponse<T>()
            {
                StatusCode = "200",
                Succeeded = true,
                Message = message,
                Data = data
            };
        }

        /// <summary>
        /// Creates a failed response with a custom message and status code.
        /// </summary>
        /// <param name="message">The failure message (default is "Failed.").</param>
        /// <param name="statusCode">The failure status code (default is "400").</param>
        /// <returns>A failed <see cref="BaseResponse{T}"/>.</returns>
        public static BaseResponse<T> Failed(string message = "Failed.", string statusCode = "400")
        {
            return new BaseResponse<T>()
            {
                StatusCode = statusCode,
                Message = message,
                Succeeded = false,
            };
        }

        /// <summary>
        /// Creates a failed response with a default message and status code.
        /// </summary>
        /// <returns>A failed <see cref="BaseResponse{T}"/>.</returns>
        public static BaseResponse<T> Failed()
        {
            return new BaseResponse<T>()
            {
                StatusCode = "400",
                Message = "Failed",
                Succeeded = false,
            };
        }
    }

    // Uncomment and implement if needed
    // /// <summary>
    // /// Represents a base response containing a collection of data.
    // /// </summary>
    // /// <typeparam name="T">The type of data in the collection.</typeparam>
    // public class BaseCollectionResponse<T> : AppResponse 
    // {
    //     public IEnumerable<T> Data { get; set; }
    // }

    /// <summary>
    /// Represents a basic response with status, success flag, and a message.
    /// </summary>
    public class AppResponse
    {
        /// <summary>
        /// Gets or sets the status code of the response.
        /// </summary>
        public string StatusCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the response indicates success.
        /// </summary>
        public bool Succeeded { get; set; }

        /// <summary>
        /// Gets or sets the message associated with the response.
        /// </summary>
        public string Message { get; set; }

        public static AppResponse Failed()
        {
            return new AppResponse()
            {
                StatusCode = "400",
                Message = "Failed",
                Succeeded = false,
            };
        }
        public static AppResponse Success()
        {
            return new AppResponse()
            {
                StatusCode = "200",
                Succeeded = true,
                Message = "Succeeded."
            };
        }
    }
}
