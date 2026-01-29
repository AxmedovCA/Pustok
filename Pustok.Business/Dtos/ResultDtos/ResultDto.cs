using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Dtos.ResultDtos
{
    public class ResultDto
    {
        public bool IsSucced { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }=string.Empty;

        public ResultDto()
        {
            IsSucced = true;
            StatusCode = 200;
            Message = "Successfully";
        }

        public ResultDto(string message):this()
        {
            Message = message;
            
        }
        public ResultDto(string message,int statusCode):this(message)
        {
            Message = message;
            StatusCode = statusCode;
        }
        public ResultDto(string message, int statusCode,bool isSucced):this(message,statusCode)
        {
            IsSucced = isSucced;
            Message = message;
            StatusCode=statusCode;  
        }

    }
    public class ResultDto<T> :ResultDto 
    {
    
        public T? Data { get; set; }

        public ResultDto():base()
        {
            
        }
        public ResultDto(T data):this() 
        {
            Data = data;
        }
        public ResultDto(string message,T data) : base(message)
        {
            Data = data;
        }
        public ResultDto(string message,int statusCode, T data):base(message,statusCode)
        {
            Data=data;
        }
        public ResultDto(string message, int statusCode,bool isSucced, T data) : base(message, statusCode,isSucced)
        {
            Data = data;
        }

    }
    
    
}
