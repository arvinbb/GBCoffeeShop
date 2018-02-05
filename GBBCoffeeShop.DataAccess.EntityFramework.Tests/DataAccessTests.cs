using System;
using GBBCoffeeShop.Business.Entities;
using GBBCoffeeShop.DataAccess.EntityFramework.Domain;
using GBBCoffeeShop.DataAccess.EntityFramework.Domain.Repositories;
using GBBCoffeeShop.DataAccess.EntityFramework.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GBBCoffeeShop.DataAccess.EntityFramework.Tests
{
    [TestClass]
    public class DataAccessTests
    {
        IUnitOfWork unitOrWork;
        IShopProductRepository productRepository;
        IShopSaleRepository saleRepository;

        [TestInitialize]
        public void Setup()
        {
            CoffeeContext context = CoffeeContext.GetContext();
            // Seed the EntityFramework In-Memory database with values
            context.SeedData();
            unitOrWork = new UnitOfWork(context);
            productRepository = unitOrWork.Products;
            saleRepository = unitOrWork.Sales;
        }

        [TestMethod]
        public void SaleRepository_GetSale()
        {
            var sale = saleRepository.GetSale(1);
            Assert.AreEqual(sale.Id, 1);
        }

        [TestMethod]
        public void SaleRepository_UpdateSaleStatus()
        {
            var sale = saleRepository.GetSale(1);
            sale.Status = "PREPARING";
            unitOrWork.Save();
            
            var saleUpdated = saleRepository.GetSale(1);
            Assert.AreEqual(saleUpdated.Status, "PREPARING");
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
            unitOrWork.Save();
            var saleUpdated = saleRepository.GetSale(2);
            Assert.AreEqual(saleUpdated.SalePrice, 2.0m);
        }
    }
}
