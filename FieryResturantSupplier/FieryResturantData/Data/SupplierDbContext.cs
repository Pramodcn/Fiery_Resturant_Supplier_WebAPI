using FieryResturant.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieryResturantData.Data
{
    public class SupplierDbContext : DbContext
    {
        //DbContest having Constuctor
        public SupplierDbContext(DbContextOptions<SupplierDbContext> options) : base(options)
        {
            //Built in Dependency Injection


        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-MRV4MIM;Initial Catalog=Supplie;Integrated Security=True;TrustServerCertificate=True");
        //}
        public DbSet<Address> addresses { get; set; }
        public DbSet<Business> businesss { get; set; }
        public DbSet<Supplier> suppliers { get; set; }
    }
}
