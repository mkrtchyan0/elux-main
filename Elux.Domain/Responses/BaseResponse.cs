using Elux.Domain.Entities;
using Elux.Domain.Responses.User;

namespace Elux.Domain.Responses
{
    public class BaseResponse<T> : AppResponse
    {
        public T Data { get; private set; }

        public static BaseResponse<T> Success()
        {
            return new BaseResponse<T>()
            {
                StatusCode = "200",
                Message = "Succeded.",
                Succeeded = true,
            };
        }
        public static BaseResponse<T> Success(string message)
        {
            return new BaseResponse<T>()
            {
                StatusCode = "200",
                Succeeded = true,
                Message = message
            };
        }
        public static BaseResponse<T> Success(T data)
        {
            return new BaseResponse<T>()
            {
                Data = data,
                StatusCode = "200",
                Succeeded = true,
                Message = "Succeded."
            };
        }
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
        public static BaseResponse<T> Failed(string message = "Failed.", string statusCode = "400")
        {
            return new BaseResponse<T>()
            {
                StatusCode = statusCode,
                Message = message,
                Succeeded = false,
            };
        }
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
    //public class BaseCollectionResponse<T> : AppResponse 
    //{
    //    public IEnumerable< T> Data { get; set; }
    //}

    public class AppResponse
    {
        public string StatusCode { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}

