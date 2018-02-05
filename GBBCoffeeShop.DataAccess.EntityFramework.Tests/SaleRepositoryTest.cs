using System;
using GBBCoffeeShop.Business.Entities;
using GBBCoffeeShop.DataAccess.EntityFramework.Domain;
using GBBCoffeeShop.DataAccess.EntityFramework.Domain.Repositories;
using GBBCoffeeShop.DataAccess.EntityFramework.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GBBCoffeeShop.DataAccess.EntityFramework.Tests
{
    [TestClass]
    public class SaleRepositoryTest
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
        public void SaleRepository_GetSale()
        {
            var sale = saleRepository.GetSale(1);
            Assert.AreEqual(1, sale.Id);
        }

        [TestMethod]
        public void SaleRepository_UpdateSaleStatus()
        {
            var sale = saleRepository.GetSale(1);
            sale.Status = "PREPARING";
            unitOfWork.Save();
            
            var saleUpdated = saleRepository.GetSale(1);
            Assert.AreEqual("PREPARING", saleUpdated.Status);
        }

        [TestMethod]
        public void SaleRepository_CreateSale()
        {
            var sale = new Sale
            {
                DateCreated = DateTime.Now,
                SalePrice = 2.0m
            };
            saleRepository.Add(sale);            
            unitOfWork.Save();
            var saleUpdated = saleRepository.GetSale(2);
            Assert.AreEqual(2.0m, saleUpdated.SalePrice);
        }
    }
}
