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
    [RoutePrefix("v1/products")]
    public class CoffeeShopController : ApiController
    {
        [Dependency]
        public ICoffeeShopService CoffeeShopService { get; set; }


    }
}
