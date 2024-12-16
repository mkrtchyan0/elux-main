namespace Elux.Domain.Responses
{
    /// <summary>
    /// Represents a paginated response that contains data and pagination details.
    /// </summary>
    /// <typeparam name="T">The type of data being returned.</typeparam>
    public class PaginatedResponse<T> : AppResponse
    {
        //TestCommit2
        /// <summary>
        /// Gets the current page index (zero-based).
        /// </summary>
        public int PageIndex { get; private set; }

        /// <summary>
        /// Gets the size of a single page.
        /// </summary>
        public int PageSize { get; private set; }

        /// <summary>
        /// Gets the total number of items across all pages.
        /// </summary>
        public int TotalCount { get; private set; }

        /// <summary>
        /// Gets the total number of pages.
        /// </summary>
        public int TotalPages { get; private set; }

        /// <summary>
        /// Gets the data for the current page.
        /// </summary>
        public T Data { get; private set; }

        /// <summary>
        /// Default constructor. Initializes a new instance of the <see cref="PaginatedResponse{T}"/> class.
        /// </summary>
        public PaginatedResponse()
        {
        }

        /// <summary>
        /// Parameterized constructor for creating a paginated response.
        /// </summary>
        /// <param name="data">The data to include in the response.</param>
        /// <param name="index">The current page index.</param>
        /// <param name="size">The page size.</param>
        /// <param name="totalCount">The total number of items.</param>
        /// <param name="totalPages">The total number of pages.</param>
        public PaginatedResponse(T data, int index, int size, int totalCount, int totalPages)
        {
            Data = data;
            PageIndex = index;
            PageSize = size;
            TotalCount = totalCount;
            TotalPages = totalPages;
        }

        /// <summary>
        /// Creates a successful response with a default status code and message.
        /// </summary>
        /// <returns>A successful <see cref="PaginatedResponse{T}"/>.</returns>
        public static PaginatedResponse<T> Success()
        {
            return new PaginatedResponse<T>()
            {
                StatusCode = "200",
                Message = "Succeeded.",
                Succeeded = true,
            };
        }

        /// <summary>
        /// Creates a successful response with a custom message.
        /// </summary>
        /// <param name="message">The success message.</param>
        /// <returns>A successful <see cref="PaginatedResponse{T}"/>.</returns>
        public static PaginatedResponse<T> Success(string message)
        {
            return new PaginatedResponse<T>()
            {
                StatusCode = "200",
                Succeeded = true,
                Message = message
            };
        }

        /// <summary>
        /// Creates a successful response with data.
        /// </summary>
        /// <param name="data">The data to include in the response.</param>
        /// <returns>A successful <see cref="PaginatedResponse{T}"/>.</returns>
        public static PaginatedResponse<T> Success(T data)
        {
            return new PaginatedResponse<T>()
            {
                Data = data,
            };
        }

        /// <summary>
        /// Creates a successful response with a custom message and data.
        /// </summary>
        /// <param name="message">The success message.</param>
        /// <param name="data">The data to include in the response.</param>
        /// <returns>A successful <see cref="PaginatedResponse{T}"/>.</returns>
        public static PaginatedResponse<T> Success(string message, T data)
        {
            return new PaginatedResponse<T>()
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
        /// <returns>A failed <see cref="PaginatedResponse{T}"/>.</returns>
        public static PaginatedResponse<T> Failed(string message = "Failed.", string statusCode = "400")
        {
            return new PaginatedResponse<T>()
            {
                StatusCode = statusCode,
                Message = message,
                Succeeded = false,
            };
        }

        /// <summary>
        /// Creates a failed response with a default message and status code.
        /// </summary>
        /// <returns>A failed <see cref="PaginatedResponse{T}"/>.</returns>
        public static PaginatedResponse<T> Failed()
        {
            return new PaginatedResponse<T>()
            {
                StatusCode = "400",
                Message = "Failed",
                Succeeded = false,
            };
        }
    }
}
