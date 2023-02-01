using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieryResturantDTO.Filter
{
    public class PaginationFilter
    {
        public PaginationFilter() 
        { 
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PaginationFilter(int PageNumber,int PageSize) 
        { 
            this.PageNumber = PageNumber < 1 ? 1 : PageNumber;
            this.PageSize = PageSize > 10 ? 10 : PageSize;
        }

    }
}
