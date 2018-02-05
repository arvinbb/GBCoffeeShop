using GBBCoffeeShop.DataAccess.EntityFramework.Domain;
using GBBCoffeeShop.DataAccess.EntityFramework.Domain.Repositories;
using GBBCoffeeShop.DataAccess.EntityFramework.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBBCoffeeShop.DataAccess.EntityFramework.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CoffeeContext _context;

        public UnitOfWork(CoffeeContext context)
        {
            _context = context;
            Products = new ShopProductRepository(_context);
            Sales = new ShopSaleRepository(_context);
        }
        
        public IShopProductRepository Products { get; private set; }
        public IShopSaleRepository Sales { get; private set; }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
