using GBBCoffeeShop.Business.Entities;
using GBBCoffeeShop.DataAccess.EntityFramework.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GBBCoffeeShop.DataAccess.EntityFramework.Persistence.Repositories
{
    public class ShopSaleRepository : Repository<Sale>, IShopSaleRepository
    {
        public CoffeeContext CoffeeContext
        {
            get { return Context as CoffeeContext; }
        }

        public ShopSaleRepository(CoffeeContext context)
            : base(context)
        {
        }

        public Sale GetSale(long id)
        {
            return CoffeeContext.Sales
                .Include(a => a.Items)
                .Include(a => a.User)
                .SingleOrDefault(a => a.Id == id);
        }
        
    }
}
