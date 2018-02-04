using GBBCoffeeShop.Business.Entities;
using System.Collections.Generic;

namespace GBBCoffeeShop.DataAccess.EntityFramework.Domain.Repositories
{
    public interface IShopProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetShopMenu(int pageIndex, int pageSize);
    }
}