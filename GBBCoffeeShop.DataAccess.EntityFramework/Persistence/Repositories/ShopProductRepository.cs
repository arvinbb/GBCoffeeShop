using GBBCoffeeShop.Business.Entities;
using GBBCoffeeShop.DataAccess.EntityFramework.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GBBCoffeeShop.DataAccess.EntityFramework.Persistence.Repositories
{
    public class ShopProductRepository : Repository<Product>, IShopProductRepository
    {
        public CoffeeContext CoffeeContext
        {
            get { return Context as CoffeeContext; }
        }

        public ShopProductRepository(CoffeeContext context)
            : base(context)
        {
        }

        public Product GetProduct(long id)
        {
            return CoffeeContext.Products
             .Where(p => p.Id == id)
             .SingleOrDefault();
        }

        public IEnumerable<Product> GetProducts(int pageIndex, int pageSize)
        {
            return CoffeeContext.Products
             //.Include(c => c)
             .OrderBy(c => c.Name)
             .Skip((pageIndex - 1) * pageSize)
             .Take(pageSize)
             .ToList();
        }

        public IEnumerable<Product> SearchProducts(string name, int pageIndex, int pageSize)
        {
            return CoffeeContext.Products
             .Where(p => p.Name.IndexOf(name, StringComparison.InvariantCultureIgnoreCase) >= 0)
             .OrderBy(c => c.Name)
             .Skip((pageIndex - 1) * pageSize)
             .Take(pageSize)
             .ToList();
        }


    }
}
