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
        public void CreateSale(Sale sale)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts(int pageIndex, int pageSize)
        {
            using (var client = new WCFServiceClientWrapper<ICoffeeShopService>())
            {
                return client.Channel.GetProducts(pageIndex, pageSize);
            }
        }

        public Sale GetSale(long id)
        {
            using (var client = new WCFServiceClientWrapper<ICoffeeShopService>())
            {
                return client.Channel.GetSale(id);
            }
        }

        public IEnumerable<Product> SearchProducts(string name, int pageIndex, int pageSize)
        {
            using (var client = new WCFServiceClientWrapper<ICoffeeShopService>())
            {
                return client.Channel.SearchProducts(name, pageIndex, pageSize);
            }
        }

        public void UpdateProductAvailabilityForSale(long id, bool availability)
        {
            using (var client = new WCFServiceClientWrapper<ICoffeeShopService>())
            {
                client.Channel.UpdateProductAvailabilityForSale(id, availability);
            }
        }

        public void UpdateSale(Sale sale)
        {
            using (var client = new WCFServiceClientWrapper<ICoffeeShopService>())
            {
                client.Channel.UpdateSale(sale);
            }
        }

        public void UpdateSaleStatus(long id, string status)
        {
            using (var client = new WCFServiceClientWrapper<ICoffeeShopService>())
            {
                client.Channel.UpdateSaleStatus(id, status);
            }
        }
    }
}
