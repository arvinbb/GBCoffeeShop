using GBBCoffeeShop.Business.Interfaces;
using GBBCoffeeShop.Common;
using GBBCoffeeShop.WebApi.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unity.Attributes;

namespace GBBCoffeeShop.WebApi.Controllers
{
    [RoutePrefix("v1/Products")]
    public class ProductsController : ApiController
    {
        [Dependency]
        public ICoffeeShopService CoffeeShopService { get; set; }

        [Dependency]
        public LoggingService LogService { get; set; }

        /// <summary>
        /// Gets the Coffee Shop Sales the specified Id
        /// Sample: GET: v1/products
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>        
        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = CoffeeShopService.GetProducts(1,1000);
            return Ok(result);
        }

        /// <summary>
        /// Search for a product by name
        /// Sample: GET: v1/products/latte/0/100 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("{nameToSearch}/{pageIndex:int=0}/{pageSize:int=100}")]
        [HttpGet]
        public IHttpActionResult Get(string nameToSearch, int pageIndex, int pageSize)
        {
            var result = CoffeeShopService.SearchProducts(nameToSearch, pageIndex, pageSize);
            return Ok(result);
        }

        /// <summary>
        /// This is updatable by the barista or cashier.
        /// In a coffee shop setting, it can be hard to gauge the actual number of coffee cups that can be made
        /// from the available coffee beans and/or other ingredients. This will just be updated by
        /// the barista or cashier as information becomes available.
        /// </summary>
        [Route("{id:long}/availability")]
        [HttpPost]
        public IHttpActionResult UpdateProductAvailability(long id, ProductAvailabilityUpdateRequest availabilityUpdateRequest)
        {
            try
            {
                CoffeeShopService.UpdateProductAvailabilityForSale(id, availabilityUpdateRequest.AvailabilityForSale);
                return Ok();
            }
            catch(ArgumentException ex)
            {
                LogService.Exception("Error in UpdateProductAvailability", ex);
                return BadRequest("Specified id not found: " + id.ToString());
            }
        }

    }
}
