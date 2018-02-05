using System;

namespace GBBCoffeeShop.Business.Entities
{
    /// <summary>
    /// The products of the Coffee Shop
    /// </summary>    
    public class Product
    {
        /// <summary>
        /// The unique Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The name of the product
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The price of a single product
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// This is updatable by the barista or cashier.
        /// In a coffee shop setting, it can be hard to gauge the actual number of coffee cups that can be made
        /// from the available coffee beans and/or other ingredients. This will just be updated by
        /// the barista or cashier as information becomes available.
        /// </summary>
        public bool IsAvailableForSale { get; set; }

    }
    
}
