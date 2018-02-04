using System;
using System.Collections.Generic;
using System.Text;

namespace GBBCoffeeShop.Business.Entities
{
    [Serializable]
    public class SaleItem
    {
        public long Id { get; set; }

        public decimal UnitPrice { get; set; }

        public Product ProductItem { get; set; }
    }
}
