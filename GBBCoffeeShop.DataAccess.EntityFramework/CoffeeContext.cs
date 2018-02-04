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

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

    }
}
