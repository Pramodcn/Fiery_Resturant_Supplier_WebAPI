using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieryResturantDTO.Wrapper
{
    public class Response<T>
    {
        public Response() { }
        public Response(T data)
        {
            Succeeded= true;
            Errors = null;
            Message = string.Empty;
            Data= data;

        }
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }
    }
}
