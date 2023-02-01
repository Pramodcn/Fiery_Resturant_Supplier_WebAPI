using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieryResturantDTO
{
    public class SupplierDTO
    {
        public string? SupplierID { get; set; }
        public string? SupplierName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public bool IsActive { get; set; }
        public BusinessDTO ? Business { get; set; }
        public AddressDTO ? Address { get; set; }
    }
}
