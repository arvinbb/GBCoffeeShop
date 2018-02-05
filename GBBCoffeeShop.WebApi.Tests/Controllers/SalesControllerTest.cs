using System;
using System.Web.Http;
using System.Web.Http.Results;
using GBBCoffeeShop.Business.Entities;
using GBBCoffeeShop.Business.Interfaces;
using GBBCoffeeShop.Common;
using GBBCoffeeShop.WebApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GBBCoffeeShop.WebApi.Tests.Controllers
{
    [TestClass]
    public class SalesControllerTest
    {
        [TestMethod]
        public void GetSale()
        {   

            var controller = new SalesController();
            controller.LogService = LoggingService.Log;
            var mockShopService = new Mock<ICoffeeShopService>();
            mockShopService.Setup(x => x.GetSale(1))
                .Returns(new Sale { Id=1 });

            controller.CoffeeShopService = mockShopService.Object;

            IHttpActionResult actionResult = controller.Get(1);
            var contentResult = actionResult as OkNegotiatedContentResult<Sale>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.Id);
        }

        [TestMethod]
        public void UpdateSaleStatus()
        {

            var controller = new SalesController();
            controller.LogService = LoggingService.Log;
            var mockShopService = new Mock<ICoffeeShopService>();
            mockShopService.Setup(x => x.UpdateSaleStatus(1, "SERVED"));                

            controller.CoffeeShopService = mockShopService.Object;

            IHttpActionResult actionResult = controller.UpdateSaleStatus(1, new Request.SaleStatusUpdateRequest {Status="SERVED"});
            

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }

        [TestMethod]
        public void UpdateSaleStatusException()
        {

            var controller = new SalesController();
            controller.LogService = LoggingService.Log;
            var mockShopService = new Mock<ICoffeeShopService>();
            mockShopService.Setup(x => x.UpdateSaleStatus(1, "SERVED"))               
                .Throws(new ArgumentException());

            controller.CoffeeShopService = mockShopService.Object;

            IHttpActionResult actionResult = controller.UpdateSaleStatus(1, new Request.SaleStatusUpdateRequest { Status = "SERVED" });
            
            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestErrorMessageResult));
        }
    }
}
