using GBBCoffeeShop.Business.Entities;

namespace GBBCoffeeShop.DataAccess.EntityFramework.Domain.Repositories
{
    /// <summary>
    /// Repository for all Sale related queries
    /// </summary>
    public interface IShopSaleRepository : IRepository<Sale>
    {
        /// <summary>
        /// Gets a sale via Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Sale GetSale(long id);
        
    }
    
}