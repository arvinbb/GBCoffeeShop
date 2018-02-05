using System;
using System.Linq;
using GBBCoffeeShop.Business.Entities;
using GBBCoffeeShop.DataAccess.EntityFramework.Domain;
using GBBCoffeeShop.DataAccess.EntityFramework.Domain.Repositories;
using GBBCoffeeShop.DataAccess.EntityFramework.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GBBCoffeeShop.DataAccess.EntityFramework.Tests
{
    [TestClass]
    public class ProductRepositoryTest
    {
        static IUnitOfWork unitOfWork;
        static IShopProductRepository productRepository;
        static IShopSaleRepository saleRepository;

        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            CoffeeContext context = CoffeeContext.GetContext(new Guid().ToString());
            // Seed the EntityFramework In-Memory database with values
            context.SeedData();
            unitOfWork = new UnitOfWork(context);
            productRepository = unitOfWork.Products;
            saleRepository = unitOfWork.Sales;
        }

        [TestMethod]
        public void ProductRepository_GetProducts()
        {
            var products = productRepository.GetProducts(1, 1000);            
            Assert.AreEqual(3, products.Count());
        }

        [TestMethod]
        public void ProductRepository_GetProduct()
        {
            var product = productRepository.GetProduct(1);
            Assert.AreEqual("Caffe Americano", product.Name);
            Assert.AreEqual(5.0m, product.UnitPrice);
        }

        [TestMethod]
        public void ProductRepository_SearchProducts()
        {
            var products = productRepository.SearchProducts("latte", 1, 100);

            Assert.AreEqual(1, products.Count());
            Assert.AreEqual("Caffe Latte", products.Single().Name);
        }


        [TestMethod]
        public void ProductRepository_UpdateAvailability()
        {
            var product = productRepository.GetProduct(1);
            product.IsAvailableForSale = false;
                        
            unitOfWork.Save();

            var productUpdated = productRepository.GetProduct(1);            
            Assert.AreEqual(false, product.IsAvailableForSale);
        }
    }
}
