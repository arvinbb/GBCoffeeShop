using GBBCoffeeShop.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unity.Attributes;

namespace GBBCoffeeShop.WebApi.Controllers
{
    [RoutePrefix("v1/sales")]
    public class SalesController : ApiController
    {
        [Dependency]
        public ICoffeeShopService CoffeeShopService { get; set; }

        // GET: api/sales/2
        /// <summary>
        /// Gets the Coffee Shop Sales the specified Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id:long}")]
        [HttpGet]
        public IHttpActionResult Get(long id)
        {
            var result = CoffeeShopService.GetSale(id);
            if (result != null && result.Id > 0)
                return Ok(result);
            else
                return NotFound();            
        }
    }
}
