using FieryResturant.Entites;
using FieryResturantDTO;
using FieryResturantServices.InterfaceDTO.Implementation;
using FieryResturantServices.InterfaceDTO.Interface;
using FieryResturantSupplier.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Moq;

namespace UnitTestt
{
    public class FieryControllerTest
    {
        //Get
        [Fact]
        public void Get_OnSuccess_ReturnStatusCode200()
        {
            //Arrange
            var MockSupplierService = new Mock<ISupplierDto>();
            MockSupplierService.Setup(service => service.GetSupplierService()).Returns(new List<SupplierDTO>());
            var controller = new SupplierController(MockSupplierService.Object);
            //Act
            var result = controller.GetSupplier();
            //Assert
            MockSupplierService.Verify(service => service.GetSupplierService(), Times.Once());
        }
        [Fact]
        public void Task_Get_OnSuccess_returnListOfsupplier()
        {
            var MockSupplierService = new Mock<ISupplierDto>();
            MockSupplierService.Setup(service => service.GetSupplierService()).Returns(new List<SupplierDTO>()
            {
                new()
                {
                SupplierID = "SU6381051257",
                SupplierName = "Test",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "string",
                    IsActive= true,
                    Business = null,
                    Address = null                
                },
            });
            var controller = new SupplierController(MockSupplierService.Object);
            var result = controller.GetSupplier();
            MockSupplierService.Verify(service => service.GetSupplierService(), Times.Once());
        }

       
        public  void TaskAddValidDataReturnOkResult()
        {
            //Arrange
            var MockSupplierService = new Mock<ISupplierService>();
            var post = new Supplier()
            {
                SupplierID = "SU6381051257",
                SupplierName = "Test",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "string",
                IsActive = true,
                BusinessId = 8,
                AddressId = 8,
                Business = new Business()
                {
                    BusinessID = 8,
                    BusinessName = "Test",
                    LicenseNo = 0,
                    LicenseDate = DateTime.Now
                },
                Address = new Address()
                {
                    AddressID = 8,
                    StreetAddress = "String",
                    City = "String",
                    State = "String",
                    Contry = "String",
                    ZipCode = 0,
                    Longitude = "String",
                    Latitude = "String"
                }
            };
            //Act
            var controller = new SupplierController(MockSupplierService.Object);
            var result = controller.PostSupplier(post);
            MockSupplierService.Verify(service => service.AddNewSupplierService(post), Times.Once());
        }
        //GetById
        [Fact]
        public void Task_GetsSupplierById_return_FoundSupplierResultOk()
        {
            //Arrange
            var MockSupplierService = new Mock<ISupplierService>();
            var ID = new Supplier()
            {
                SupplierID = "SU6381051257",
                SupplierName = "Test",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "string",
                IsActive = true,
                BusinessId = 8,
                
                Business = new Business()
                {
                    BusinessID = 8,
                    BusinessName = "Test",
                    LicenseNo = 0,
                    LicenseDate = DateTime.Now,
                },
                AddressId = 8,
                Address = new Address()
                {
                    AddressID = 8,
                    StreetAddress = "String",
                    City = "String",
                    State = "String",
                    Contry = "String",
                    ZipCode = 0,
                    Longitude = "String",
                    Latitude = "String"
                }
            };
            //Act
            var res = new SupplierController(MockSupplierService.Object);
            var result = res.GetId("SU6381051257");
            MockSupplierService.Verify(service => service.GetSupplierByIdService("SU6381051257"), Times.Once());

        }
    }
}