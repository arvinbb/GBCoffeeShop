using GBBCoffeeShop.Business.Entities;

namespace GBBCoffeeShop.DataAccess.EntityFramework.Domain.Repositories
{
    public interface IShopSaleRepository : IRepository<Sale>
    {
        Sale GetSale(long id);
    }
    
}