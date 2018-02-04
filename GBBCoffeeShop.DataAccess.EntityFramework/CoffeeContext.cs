using GBBCoffeeShop.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions;
using System;

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
                Id = 1,
                Name = "Cafe Americano",
                UnitPrice = 5.9m
            };

            Products.Add(product1);
            
            var product2 = new Product
            {
                Id = 2,
                Name = "Caffe Latte",
                UnitPrice = 6.9m
            };
            Products.Add(product2);

            var product3 = new Product
            {
                Id = 3,
                Name = "Caffe Mocha",
                UnitPrice = 4.9m
            };
            Products.Add(product3);

            SaveChanges();
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

    }
}
