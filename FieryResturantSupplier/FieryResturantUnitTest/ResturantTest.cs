using FieryResturant.Entites;
using FieryResturantDTO;
using FieryResturantServices.InterfaceDTO.Implementation;
using FieryResturantServices.InterfaceDTO.Interface;
using FieryResturantSupplier.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FieryResturantUnitTest
{
    public class ResturantTest
    {
        //Get
        [Fact]
        public void Get_OnSuccess_ReturnStatusCode200()
        {
            //Arrange
            var MockSupplierService = new Mock<ISupplierDto>();
            MockSupplierService.Setup(service => service.GetSupplierService())
                .Returns(new List<SupplierDTO>());
            var controller = new SupplierController(MockSupplierService.Object);
            //Act
            var result = controller.GetSupplier();
            //Assert
            MockSupplierService.Verify(service => service.GetSupplierService(), Times.Once());
        }
        [Fact]
        public void Task_Get_OnSuccess_ReturnListOfSupplier()
        {
            var MockSupplierService = new Mock<ISupplierDto>();
            MockSupplierService.Setup(service => service.GetSupplierService())
                .Returns(new List<SupplierDTO>()
                {
                    new()
                    {
            SupplierID = "SU6381052170",
            SupplierName= "Raghuu",
            LastModifiedDate = DateTime.Now,
            LastModifiedBy = "Dhanu",
            IsActive= true,
            Business = null,
            Address = null
            }
                });
            var controller = new SupplierController(MockSupplierService.Object);
            var result = controller.GetSupplier();
            MockSupplierService.Verify(service => service.GetSupplierService(), Times.Once());
        }
        //Add
        [Fact]
        public void Task_Add_ValidData_Return_OkResult()
        {
            //Arrange
            var MockSupplierService = new Mock<ISupplierDto>();
            var post = new Supplier()
            {
                SupplierID = "SU6381052170",
                SupplierName = "Raghuu",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Dhanu",
                IsActive = true,
                BusinessId = 9,
                Business = new Business()
                {
                    BusinessID = 9,
                    BusinessName = "Puma",
                    LicenseNo = 18,
                    LicenseDate = DateTime.Now,
                },
                Address = new Address()
                {
                    AddressID = 9,
                    StreetAddress = "RR nagar",
                    City = "Banglore",
                    State = "Karnataka",
                    Contry = "India",
                    ZipCode = 56008,
                    Longitude = "South",
                    Latitude = "North",
                }
            };
            //Act
            var controller = new SupplierController(MockSupplierService.Object);
            var result = controller.PostSupplier(post);
            MockSupplierService.Verify(service => service.AddNewSupplierService(post), Times.Once());
        }
        //GetbyId
        [Fact]
        public void Task_GetSupplierById_Return_FoundSupplierResultOK()
        {
            //Arrange
            var MockSupplierService = new Mock<ISupplierDto>();
            var post = new Supplier()
            {
                SupplierID = "SU6381052170",
                SupplierName = "Raghuu",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Dhanu",
                IsActive = true,
                BusinessId = 9,
                Business = new Business()
                {
                    BusinessID = 9,
                    BusinessName = "Puma",
                    LicenseNo = 18,
                    LicenseDate = DateTime.Now,
                },
                Address = new Address()
                {
                    AddressID = 9,
                    StreetAddress = "RR nagar",
                    City = "Banglore",
                    State = "Karnataka",
                    Contry = "India",
                    ZipCode = 56008,
                    Longitude = "South",
                    Latitude = "North",
                }
            };
            //Act
            var sut = new SupplierController(MockSupplierService.Object);
            var result = sut.GetId("SU6381052170");
            MockSupplierService.Verify(service => service.GetSupplierByIdService("SU6381052170"), Times.Once());
        }
    }
}
