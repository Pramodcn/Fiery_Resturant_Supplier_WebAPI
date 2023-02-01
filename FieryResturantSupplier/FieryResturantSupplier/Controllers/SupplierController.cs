using AutoMapper;
using FieryResturant.Entites;
using FieryResturantData.Interface;
using FieryResturantData.Repository;
using FieryResturantDTO;
using FieryResturantDTO.Filter;
using FieryResturantDTO.Wrapper;
using FieryResturantServices.InterfaceDTO.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FieryResturantSupplier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        //private readonly ISupplier repo;
        //private readonly IMapper mapper;
        //public SupplierController(ISupplier repos, IMapper map)
        //{
        //    this.repo = repos;
        //    this.mapper = map;
        //}
        private readonly ISupplierDto _supplierService;
        public SupplierController(ISupplierDto supplierDto)
        {
          this._supplierService = supplierDto;
        }

        [HttpPost]
        [Route("Supplier")]
        public IActionResult PostSupplier(Supplier supplier)
        {
            try
            {
               _supplierService.AddNewSupplierService(supplier);
                return Created($"api/a{supplier.SupplierID}",supplier);
                
                //return CreatedAtAction(nameof(GetSupplier), new {SupplierDto2.SupplierID }, supplier);
                // return CreatedAtAction($"api/A/{SupplierDto2.SupplierID}", supplier);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public ActionResult GetSupplier()
        {
            try
            {
                var SupplierDto1 = _supplierService.GetSupplierService();
                return Ok(SupplierDto1);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("Supplier{id}")]
        public ActionResult<Supplier> GetId(string id)
        {
            try
            {
                var SupplierDto3 = _supplierService.GetSupplierByIdService(id);
               
                    return Ok(SupplierDto3);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("Pagination")]
        public IActionResult Get([FromQuery] PaginationFilter pageFilteration)
        {
            try
            {
                var validFilter = new PaginationFilter(pageFilteration.PageNumber, pageFilteration.PageSize);
                var pageData = _supplierService.GetSupplierService().Skip((validFilter.PageNumber - 1) * pageFilteration.PageSize)
                               .Take(validFilter.PageSize).ToList();
                var TotalRecords = _supplierService.GetSupplierService().Count();
                return Ok(new PageResonse<List<SupplierDTO>>(pageData, validFilter.PageNumber, validFilter.PageSize));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
