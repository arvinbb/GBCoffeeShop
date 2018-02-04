using System;

namespace GBBCoffeeShop.Business.Entities
{
    /// <summary>
    /// The products of the Coffee Shop
    /// </summary>
    [Serializable]
    public class Product
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public decimal UnitPrice { get; set; }
    }
    
}
