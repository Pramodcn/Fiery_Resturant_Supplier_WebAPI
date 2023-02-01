using FieryResturant.Entites;
using FieryResturantData.Data;
using FieryResturantData.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FieryResturantData.Repository
{

    public class SupplierRepository : ISupplier
    {
        private readonly SupplierDbContext _db;
        //SupplierDbContext _db = new SupplierDbContext();
        public SupplierRepository(SupplierDbContext sdb)
        {
           this._db = sdb;
        }
        public Supplier AddNewSupplier(Supplier supplier)
        {
            //Supplier supplies = new Supplier();

            //supplies.SupplierID = supplier.SupplierID;

            //var sup= _db.suppliers.Add(supplier);
            //_db.SaveChanges();
            //return sup.Entity;
            var today = DateTime.Today;
            int year = (today.Year - supplier.Business.LicenseDate.Year - 1);
            if (year >= 0)
            {
                if (year <= 10)
                {
                    Console.WriteLine("Valid License Date");
                    var a = _db.suppliers.Add(supplier);
                    _db.SaveChanges();
                    return supplier;
                }
                else
                {
                    Console.WriteLine("License Date Expired");
                }
            }
            return null;

        }

        public Supplier GetSupplierById(string id)
        {
            var supplierss = _db.suppliers.Find(id);
            return supplierss;
            //var sup = _db.suppliers.Where(x => x.SupplierID == id).First();
            //if (sup != null)
            //{
            //    return sup;
            //}
            //return null;
        }

       public ICollection<Supplier> GetSupplier()
        {

            // return (_db.suppliers.ToList());
            ICollection<Supplier> supplierss = new List<Supplier>();
            try
            {
                supplierss = _db.suppliers.ToList();
                return supplierss;
            }
            catch
            {
                return supplierss;
            }
        }
    }
}
