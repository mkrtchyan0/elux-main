using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elux.Domain.Responses
{
    public class PaginatedResponse<T> : AppResponse
    {
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }
        public T Data { get; private set; }
        public PaginatedResponse()
        {
            
        }
        public PaginatedResponse(T data, int index, int size, int totalCount, int totalPages)
        {
            Data = data;
            PageIndex = index;
            PageSize = size;
            TotalCount = totalCount;
            TotalPages = totalPages;
        }
        public static PaginatedResponse<T> Success()
        {
            return new PaginatedResponse<T>()
            {
                StatusCode = "200",
                Message = "Succeded.",
                Succeeded = true,
            };
        }
        public static PaginatedResponse<T> Success(string message)
        {
            return new PaginatedResponse<T>()
            {
                StatusCode = "200",
                Succeeded = true,
                Message = message
            };
        }
        public static PaginatedResponse<T> Success(T data)
        {
            return new PaginatedResponse<T>()
            {
                Data = data,
            };
        }
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
        public static PaginatedResponse<T> Failed(string message = "Failed.", string statusCode = "400")
        {
            return new PaginatedResponse<T>()
            {
                StatusCode = statusCode,
                Message = message,
                Succeeded = false,
            };
        }
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
