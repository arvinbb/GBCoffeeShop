using GBBCoffeeShop.DataAccess.EntityFramework.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBBCoffeeShop.DataAccess.EntityFramework.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IShopProductRepository Products { get; }
        IShopSaleRepository Sales { get; }

        int Save();
    }
}
