using GBBCoffeeShop.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions;
using System;
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
            var options = new DbContextOptions<CoffeeContext>();
            var builder = new DbContextOptionsBuilder<CoffeeContext>();
            builder.UseInMemoryDatabase("Coffee");
            options = builder.Options;
            CoffeeContext context = new CoffeeContext(options);
            return context;
        }

        public void SeedData()
        {
            var product1 = new Product
            {                
                Name = "Cafe Americano",
                UnitPrice = 5.0m
            };

            Products.Add(product1);
            
            var product2 = new Product
            {                
                Name = "Caffe Latte",
                UnitPrice = 6.0m
            };
            Products.Add(product2);

            var product3 = new Product
            {                
                Name = "Caffe Mocha",
                UnitPrice = 4.0m
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
