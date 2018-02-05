using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GBBCoffeeShop.WebApi.Request
{
    public class ProductAvailabilityUpdateRequest
    {        
        public bool AvailabilityForSale { get; set; }
    }
}