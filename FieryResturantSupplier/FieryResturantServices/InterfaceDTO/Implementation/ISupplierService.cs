using AutoMapper;
using FieryResturant.Entites;
using FieryResturantData.Interface;
using FieryResturantData.Repository;
using FieryResturantDTO;
using FieryResturantServices.InterfaceDTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieryResturantServices.InterfaceDTO.Implementation
{
    public class ISupplierService : ISupplierDto
    {
        private readonly ISupplier repo;
        private readonly IMapper mapper;
        private readonly ILoggers logger;

        public ISupplierService(ISupplier supplier, IMapper mappers, ILoggers log) 
        {
            this.repo = supplier;
            this.mapper = mappers;
            this.logger = log;
        }
        public Supplier AddNewSupplierService(Supplier supplier)
        {
            if(supplier == null)
            {
                logger.LogError("Supplier id null here");
                throw new ArgumentNullException();
            }
            else
            {
                logger.LogInfo("Supplier information is Added");
                return repo.AddNewSupplier(supplier);
            }
        }

        public ICollection<SupplierDTO> GetSupplierService()
        {
            var result = repo.GetSupplier();
            if(result == null)
            {
                logger.LogError("Error is getting in viewing");
                throw new ArgumentNullException();
            }
            else
            {
                logger.LogError("Error is getting in viewing");
                var SupplierDto = mapper.Map<ICollection<Supplier>, ICollection<SupplierDTO>>(result);
                return SupplierDto;
            }
        }

        public SupplierDTO GetSupplierByIdService(string id)
        {
            var result = repo.GetSupplierById(id);
            if(result == null)
            {
                logger.LogError($"{id}is not fond");
                throw new ArgumentNullException();
            }
            else
            {
                logger.LogInfo($"{id}is View");
                return mapper.Map<Supplier,SupplierDTO>(result);
            }
        }
    }
}
