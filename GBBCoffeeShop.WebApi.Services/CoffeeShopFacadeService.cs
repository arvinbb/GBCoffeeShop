using GBBCoffeeShop.Business.Entities;
using GBBCoffeeShop.Business.Interfaces;
using GBBCoffeeShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBBCoffeeShop.WebApi.Services
{
    public class CoffeeShopFacadeService : ICoffeeShopService
    {        
        public Sale GetSale(long id)
        {
            using (var client = new WCFServiceClientWrapper<ICoffeeShopService>())
            {
                return client.Channel.GetSale(id);
            }
        }
    }
}
