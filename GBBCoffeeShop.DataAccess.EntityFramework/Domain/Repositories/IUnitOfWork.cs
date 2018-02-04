using System;
using System.Collections.Generic;
using System.Text;

namespace GBBCoffeeShop.DataAccess.EntityFramework.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IShopProductRepository Products { get; }
        IShopSaleRepository Sales { get; }

        int Save();
    }
}
