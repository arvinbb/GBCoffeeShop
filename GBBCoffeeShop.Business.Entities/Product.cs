using System;

namespace GBBCoffeeShop.Business.Entities
{
    [Serializable]
    public class Product
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public decimal UnitPrice { get; set; }
    }
    
}
