using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using GBBCoffeeShop.Business.Entities;

namespace GBBCoffeeShop.Business.Interfaces
{

    /// <summary>
    /// Defines the service contract
    /// </summary>
    [ServiceContract(Namespace = "http://GBBCoffeeShop.com")]
    public interface ICoffeeShopService
    {
        /// <summary>
        /// Gets all the coffee shop products
        /// </summary>        
        [OperationContract]
        IEnumerable<Product> GetProducts(int pageIndex, int pageSize);

        /// <summary>
        /// Search for products by Name
        /// </summary>        
        [OperationContract]
        IEnumerable<Product> SearchProducts(string name, int pageIndex, int pageSize);

        /// <summary>
        /// This is used by the barista or cashier.
        /// In a coffee shop setting, it can be hard to gauge the actual number of coffee cups that can be made
        /// from the available coffee beans and/or other ingredients. This will just be updated by
        /// the barista or cashier as information becomes available.
        /// </summary>
        /// <param name="availability">True is the product is available for sale, otherwise false</param>
        [OperationContract]
        void UpdateProductAvailabilityForSale(long id, bool availability);

        /// <summary>
        /// Get a sale by Id
        /// </summary>        
        [OperationContract]
        Sale GetSale(long id);

        /// <summary>
        /// Updates a sale
        /// </summary>     
        [OperationContract]
        void UpdateSale(Sale sale);

        /// <summary>
        /// Create a sale
        /// </summary>    
        [OperationContract]
        void CreateSale(Sale sale);

        /// <summary>
        /// Updates the status of a sale
        /// </summary>
        /// <param name="id"></param>
        [OperationContract]
        void UpdateSaleStatus(long id, string status);
    }


}
