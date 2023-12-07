using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Application.Common.Model
{
    public class Response<T>
    {
        public object Data { get; set; }
        public string Message { get; set; }
        public bool Success {  get; set; }
        public MetaDataPagination MetaDataPagination { get; set; }

        
        public Response()
        {
            Success = false;
            Message = string.Empty;
            Data = string.Empty;
        }

        public Response(bool success)
        {
            Success=success;
            Message = string.Empty;
            Data = string.Empty;
            MetaDataPagination = null;
        }
        public Response(bool success, string message)
        {
            Success=success;
            Message = message;
            Data = string.Empty;
            MetaDataPagination = null;
        }
        public Response(object data, bool success)
        {
            Success=success;
            Data = data;
            Message = string.Empty;
            MetaDataPagination = null;
        }

        public Response(bool success, object data, MetaDataPagination metadata)
        {
            Success = success;
            Message = string.Empty;
            Data = data;
            MetaDataPagination = metadata;
        }


        public static Response<T> Ok()
        {
            return new Response<T>(true);
        }
        public static Response<T> Ok(object data)
        {
            return new Response<T>(data, true);
        }
        public static Response<T> Ok(object data, string message)
        {
            return new Response<T> { Data = data, Message = message };
        }

        public dynamic SetSuccess(bool success)
        {
            Success=success;
            return this;
        }
        public dynamic SetMessage(string message)
        {
            Message=message;
            return this;
        }
        public dynamic SetData(T data)
        {
            Data = data;
            return this;
        }

    }
}
