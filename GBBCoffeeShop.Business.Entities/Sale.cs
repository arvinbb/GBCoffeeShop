using System;
using System.Collections.Generic;
using System.Text;

namespace GBBCoffeeShop.Business.Entities
{
    [Serializable]
    public class Sale
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public IEnumerable<SaleItem>  Items { get; set; }
        public decimal SalePrice { get; set; }        
    }
}
