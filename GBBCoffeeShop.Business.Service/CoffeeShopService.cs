using GBBCoffeeShop.Business.Entities;
using GBBCoffeeShop.Business.Interfaces;
using GBBCoffeeShop.DataAccess.EntityFramework;
using GBBCoffeeShop.DataAccess.EntityFramework.Domain.Repositories;
using GBBCoffeeShop.DataAccess.EntityFramework.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBBCoffeeShop.Business.Service
{
    
    public class CoffeeShopService : ICoffeeShopService
    {
        private CoffeeContext context;

        public CoffeeShopService()
        {
            context = CoffeeContext.GetContext();
            context.SeedData();
            
        }

        public Sale GetSale(long id)
        {
            IShopProductRepository repo = new ShopProductRepository(context);
            var menu = repo.GetShopMenu(0, 1000);
            return null;

        }
    }
}
