using GBBCoffeeShop.Business.Entities;
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
    [RoutePrefix("v1/Sales")]
    public class SalesController : ApiController
    {
        [Dependency]
        public ICoffeeShopService CoffeeShopService { get; set; }

        [Dependency]
        public LoggingService LogService { get; set; }

        // GET: v1/sales/2
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
                return BadRequest("Specified id not found: " + id.ToString());             
        }

        [Route("{id}/Status")]
        [HttpPost]
        public IHttpActionResult UpdateSaleStatus([FromUri] long id, [FromBody]SaleStatusUpdateRequest statusRequest)
        {
            try
            {
                CoffeeShopService.UpdateSaleStatus(id, statusRequest.Status);
                return Ok();
            }
            catch(ArgumentException ex)
            {
                LogService.Exception("Error in UpdateSaleStatus", ex);
                return BadRequest("Specified id not found: " + id.ToString());
                
            }
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult CreateSale([FromBody]Sale sale)
        {      
            CoffeeShopService.CreateSale(sale);
            return Ok();
        }
    }
}
