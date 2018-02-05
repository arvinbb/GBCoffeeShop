using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GBBCoffeeShop.Business.Entities
{
    /// <summary>
    /// The sale item of a Sale
    /// </summary>    
    public class SaleItem
    {
        /// <summary>
        /// The unique Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        /// <summary>
        /// The Unit Price
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// The product associated with the this sale item
        /// </summary>
        public Product ProductItem { get; set; }
    }
}
