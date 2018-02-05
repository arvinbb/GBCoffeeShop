using GBBCoffeeShop.Business.Entities;
using System.Collections.Generic;

namespace GBBCoffeeShop.DataAccess.EntityFramework.Domain.Repositories
{
    /// <summary>
    /// Repository for all Product related queries
    /// </summary>
    public interface IShopProductRepository : IRepository<Product>
    {
        /// <summary>
        /// Get a product by Id
        /// </summary>                
        Product GetProduct(long id);

        /// <summary>
        /// Gets the coffee shop products menu
        /// </summary>
        IEnumerable<Product> GetProducts(int pageIndex, int pageSize);

        /// <summary>
        /// Search for products by Name
        /// </summary>        
        IEnumerable<Product> SearchProducts(string name, int pageIndex, int pageSize);
    }
}