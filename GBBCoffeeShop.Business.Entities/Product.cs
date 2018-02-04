using System;

namespace GBBCoffeeShop.Business.Entities
{
    [Serializable]
    public class Product
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal UnitPrice { get; set; }
    }
    
}
