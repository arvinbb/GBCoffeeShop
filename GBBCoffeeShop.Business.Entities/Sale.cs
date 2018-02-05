using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GBBCoffeeShop.Business.Entities
{
    /// <summary>
    /// The Sale order of a customer. 
    /// It will normally have one or more SaleItem
    /// </summary>    
    public class Sale
    {
        /// <summary>
        /// The unique Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public IEnumerable<SaleItem>  Items { get; set; }

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
        public User User { get; set; }
    }
}
