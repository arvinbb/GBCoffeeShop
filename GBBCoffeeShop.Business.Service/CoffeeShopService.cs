using GBBCoffeeShop.Business.Entities;
using GBBCoffeeShop.Business.Interfaces;
using GBBCoffeeShop.DataAccess.EntityFramework;
using GBBCoffeeShop.DataAccess.EntityFramework.Domain;
using GBBCoffeeShop.DataAccess.EntityFramework.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GBBCoffeeShop.Business.Service
{
    /// <summary>
    /// Facade Service implementation
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class CoffeeShopService : ICoffeeShopService
    {
        private IUnitOfWork unitOfWork;
        private IShopProductRepository shopProductRepository;
        private IShopSaleRepository shopSaleRepository;

        /// <summary>
        /// The repositories are taken from the unitOfWork
        /// </summary>
        /// <param name="unitOfWork">Created by DI</param>
        public CoffeeShopService(IUnitOfWork unitOfWork)
        {
            shopProductRepository = unitOfWork.Products;
            shopSaleRepository = unitOfWork.Sales;
        }


        public IEnumerable<Product> GetProducts(int pageIndex, int pageSize)
        {
            return shopProductRepository.GetProducts(pageIndex, pageSize);
        }


        public IEnumerable<Product> SearchProducts(string name, int pageIndex, int pageSize)
        {
            return shopProductRepository.SearchProducts(name, pageIndex, pageSize);
        }

        /// <summary>
        /// This is updatable by the barista or cashier.
        /// In a coffee shop setting, it can be hard to gauge the actual number of coffee cups that can be made
        /// from the available coffee beans and/or other ingredients. This will just be updated by
        /// the barista or cashier as information becomes available.
        /// </summary>        
        /// <param name="availability">True is the product is available for sale, otherwise false</param>
        public void UpdateProductAvailabilityForSale(long id, bool availability)
        {
            var product = shopProductRepository.GetProduct(id);
            if (product == null || product.Id == 0)
                throw new ArgumentException("Specified product Id is not found: " + id.ToString());

            product.IsAvailableForSale = availability;
            unitOfWork.Save();
        }



        public Sale GetSale(long id)
        {
            return shopSaleRepository.GetSale(id);
        }

        public void UpdateSale(Sale sale)
        {
            var saleEntity = shopSaleRepository.GetSale(sale.Id);
            if (saleEntity == null)
                throw new ArgumentException("Specified sale Id is not found: " + sale.Id.ToString());

            saleEntity.Items = sale.Items;
            saleEntity.SalePrice = sale.SalePrice;
            saleEntity.Status = sale.Status;
            saleEntity.TaxPrice = sale.TaxPrice;
            saleEntity.User = sale.User;

            unitOfWork.Save();
        }

        public void CreateSale(Sale sale)
        {
            shopSaleRepository.Add(sale);
        }

        public string GetSaleStatus(long id)
        {
            var sale = shopSaleRepository.GetSale(id);
            if (sale == null)
                return null;

            return sale.Status;
        }

        public void UpdateSaleStatus(long id, string status)
        {
            var sale = shopSaleRepository.GetSale(id);
            if (sale == null)
                throw new ArgumentException("Specified sale Id is not found: " + id.ToString());

            sale.Status = status;
            unitOfWork.Save();

        }

    }
}
