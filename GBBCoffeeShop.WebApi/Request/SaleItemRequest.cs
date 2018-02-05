namespace GBBCoffeeShop.WebApi.Request
{
    public class SaleItemRequest
    {
        /// <summary>
        /// The unique Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The Unit Price
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// The product associated with the this sale item
        /// </summary>
        public long ProductItemId { get; set; }
    }
}