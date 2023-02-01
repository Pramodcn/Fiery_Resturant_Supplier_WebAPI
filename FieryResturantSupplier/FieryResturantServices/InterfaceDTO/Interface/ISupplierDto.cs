using FieryResturant.Entites;
using FieryResturantDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieryResturantServices.InterfaceDTO.Interface
{
    public interface ISupplierDto
    {
         Supplier AddNewSupplierService(Supplier supplier);
         SupplierDTO GetSupplierByIdService(string id);
         ICollection<SupplierDTO> GetSupplierService();
    }
}
