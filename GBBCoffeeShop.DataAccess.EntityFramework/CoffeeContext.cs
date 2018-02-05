using GBBCoffeeShop.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions;
using System;
using System.Linq;
using System.Collections.Generic;

namespace GBBCoffeeShop.DataAccess.EntityFramework
{
    public class CoffeeContext : DbContext
    {
        public CoffeeContext(DbContextOptions<CoffeeContext> options)
            : base(options)
        {
        }

        public static CoffeeContext GetContext()
        {            
            return GetContext("GBCoffeeShop");
        }

        public static CoffeeContext GetContext(string databaseName)
        {
            var options = new DbContextOptions<CoffeeContext>();
            var builder = new DbContextOptionsBuilder<CoffeeContext>();
            builder.UseInMemoryDatabase(databaseName);
            options = builder.Options;
            CoffeeContext context = new CoffeeContext(options);
            return context;
        }

        public void SeedData()
        {
            if (Products.Count() > 0)
                return;  //run only once          

            var product1 = new Product
            {                
                Name = "Caffe Americano",
                UnitPrice = 5.0m,
                IsAvailableForSale = true
            };

            Products.Add(product1);
            
            var product2 = new Product
            {                
                Name = "Caffe Latte",
                UnitPrice = 6.0m,
                IsAvailableForSale = true
            };
            Products.Add(product2);

            var product3 = new Product
            {                
                Name = "Caffe Mocha",
                UnitPrice = 4.0m,
                IsAvailableForSale = true
            };
            Products.Add(product3);

            var user = new User
            {                
                FirstName = "Arvin",
                LastName = "Baccay",
                Role = "BARISTA"
            };
            Users.Add(user);

            var saleItem1 = new SaleItem
            {                
                ProductItem=product2,
                UnitPrice=6.0m
            };
            var saleItem2 = new SaleItem
            {                
                ProductItem = product3,
                UnitPrice = 4.0m
            };
            var sale = new Sale
            {                
                DateCreated = DateTime.Now,
                Items = new List<SaleItem>() { saleItem1, saleItem2 },
                SalePrice = 10,
                Status = "PAID",
                TaxPrice = 0m,
                User = user
            };
            Sales.Add(sale);
            
            SaveChanges();
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
