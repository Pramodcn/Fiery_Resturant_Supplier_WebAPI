using FieryResturant.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieryResturantData.Interface
{
    public interface ISupplier
    {
        public Supplier AddNewSupplier(Supplier supplier);
        public Supplier GetSupplierById(string id);
        public ICollection<Supplier> GetSupplier();
        //public bool UpdateSupplier(Supplier suplier);
    }
}
