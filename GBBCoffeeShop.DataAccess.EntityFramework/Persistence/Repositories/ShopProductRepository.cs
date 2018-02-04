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

        public IEnumerable<Product> GetShopMenu(int pageIndex, int pageSize)
        {
            return CoffeeContext.Products
             //.Include(c => c)
             .OrderBy(c => c.Name)
             .Skip((pageIndex - 1) * pageSize)
             .Take(pageSize)
             .ToList();
        }

        
    }
}
