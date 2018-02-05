using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GBBCoffeeShop.WebApi.Request
{
    public class SaleRequest
    {
        public long Id { get; set; }

        /// <summary>
        /// The status of the sale 
        /// Possible work flows are:
        ///  * PAID -> PREPARING -> SERVED
        ///  * PAID -> REFUNDED
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Date when the Sale is done
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The items associated with the sale
        /// </summary>
        public IEnumerable<SaleItemRequest> Items { get; set; }

        /// <summary>
        /// The total sale price
        /// </summary>
        public decimal SalePrice { get; set; }

        /// <summary>
        /// The tax (if any) paid
        /// </summary>
        public decimal TaxPrice { get; set; }

        /// <summary>
        /// The staff/crew that handled the sale (normally the cashier)
        /// </summary>
        public long UserId { get; set; }
    }
}