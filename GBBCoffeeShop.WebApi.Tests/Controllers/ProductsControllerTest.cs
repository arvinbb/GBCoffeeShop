using GBBCoffeeShop.Business.Entities;
using GBBCoffeeShop.Business.Interfaces;
using GBBCoffeeShop.Common;
using GBBCoffeeShop.DataAccess.EntityFramework;
using GBBCoffeeShop.DataAccess.EntityFramework.Domain;
using GBBCoffeeShop.DataAccess.EntityFramework.Domain.Repositories;
using GBBCoffeeShop.DataAccess.EntityFramework.Persistence;
using GBBCoffeeShop.WebApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace GBBCoffeeShop.WebApi.Tests.Controllers
{
    [TestClass]
    public class ProductsControllerTest
    {   

        [TestMethod]
        public void GetProducts()
        {
            var products = new List<Product>
            {
                new Product{Id=1},
                new Product{Id=2},
                new Product{Id=3},
            };

            var controller = new ProductsController();
            controller.LogService = LoggingService.Log;
            var mockShopService = new Mock<ICoffeeShopService>();
            mockShopService.Setup(x => x.GetProducts(1, 1000))
                .Returns(products);

            controller.CoffeeShopService = mockShopService.Object;

            IHttpActionResult actionResult = controller.Get();
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<Product>>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(3, contentResult.Content.Count());
        }

        [TestMethod]
        public void SearchProducts()
        {
            var products = new List<Product>
            {
                new Product{ Id =1, Name="Caffe Latte"}                
            };

            var controller = new ProductsController();
            controller.LogService = LoggingService.Log;
            var mockShopService = new Mock<ICoffeeShopService>();
            mockShopService.Setup(x => x.SearchProducts("latte", 1, 1000))
                .Returns(products);

            controller.CoffeeShopService = mockShopService.Object;

            IHttpActionResult actionResult = controller.Get("latte", 1, 1000);
            var contentResult = actionResult as OkNegotiatedContentResult<IEnumerable<Product>>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.Count());
            Assert.AreEqual("Caffe Latte", contentResult.Content.Single().Name);
        }

        [TestMethod]
        public void UpdateProductAvailability()
        {
            var products = new List<Product>
            {
                new Product{ Id =1, Name="Caffe Latte"}
            };

            var controller = new ProductsController();
            controller.LogService = LoggingService.Log;
            var mockShopService = new Mock<ICoffeeShopService>();
            mockShopService.Setup(x => x.UpdateProductAvailabilityForSale(1, false));
                

            controller.CoffeeShopService = mockShopService.Object;

            IHttpActionResult actionResult = controller.UpdateProductAvailability(1, new Request.ProductAvailabilityUpdateRequest {AvailabilityForSale=false });
            
            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }

        [TestMethod]
        public void UpdateProductAvailabilityException()
        {
            var products = new List<Product>
            {
                new Product{ Id =1, Name="Caffe Latte"}
            };

            var controller = new ProductsController();
            controller.LogService = LoggingService.Log;
            var mockShopService = new Mock<ICoffeeShopService>();
            mockShopService.Setup(x => x.UpdateProductAvailabilityForSale(1, false))
                .Throws(new ArgumentException());


            controller.CoffeeShopService = mockShopService.Object;

            IHttpActionResult actionResult = controller.UpdateProductAvailability(1, new Request.ProductAvailabilityUpdateRequest { AvailabilityForSale = false });

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestErrorMessageResult));
        }

    }
}
