using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Models
{
    public static class Response
    {
        public static Response<T> Fail<T>(string message, T data = default)
        {
            return new(data, message, false);
        }

        public static Response<T> Ok<T>(string message, T data = default)
        {
            return new(data, message, true);
        }
    }

    public class Response<T>
    {
        public Response(T data, string msg, bool isSuccess)
        {
            Data = data;
            Message = msg;
            IsSuccess = isSuccess;
        }

        public T Data { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
