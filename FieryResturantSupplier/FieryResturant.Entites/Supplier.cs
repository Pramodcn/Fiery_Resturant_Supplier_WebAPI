using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieryResturant.Entites
{
    public class Supplier
    {
        
        public Supplier() 
        {
            this.SupplierID = "SU" + DateTime.Now.Ticks.ToString().Substring(0,10);
        }
        [Key]
        public string? SupplierID { get; set; }
        public string? SupplierName { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastModifiedDate { get; set; }
        [DataType(DataType.Time)]
        public string? LastModifiedBy { get; set; }
        public bool IsActive { get; set; }
        [Required]
        [ForeignKey("Business")]
        public int BusinessId { get; set; }
        public Business ? Business { get; set; }
        [Required]
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address ? Address { get; set; }
    }
}
