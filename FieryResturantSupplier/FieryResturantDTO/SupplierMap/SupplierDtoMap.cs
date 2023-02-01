using AutoMapper;
using FieryResturant.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieryResturantDTO.SupplierMap
{
    public class SupplierDtoMap : Profile
    {
        public SupplierDtoMap() 
        {
            //Source -> Destination
            CreateMap<Supplier, SupplierDTO>();
            CreateMap<Business, BusinessDTO>();
            CreateMap<Address, AddressDTO>();
        }
    }
}
