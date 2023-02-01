using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieryResturantDTO.Wrapper
{
    public class PageResonse<T> : Response<T>
    {
        //public PageResonse() { }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }

        public PageResonse(T data, int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Data= data;
            this.Message = null;
            this.Succeeded = true;
            this.Errors = null;
        }
    }
}
