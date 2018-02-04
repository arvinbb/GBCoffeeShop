using GBBCoffeeShop.Business.Entities;
using GBBCoffeeShop.Business.Interfaces;
using GBBCoffeeShop.DataAccess.EntityFramework;
using GBBCoffeeShop.DataAccess.EntityFramework.Domain.Repositories;
using GBBCoffeeShop.DataAccess.EntityFramework.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBBCoffeeShop.Business.Service
{
        
    public class CoffeeShop : ICoffeeShop
    {
        public CoffeeShop()
        {
            
        }

        public Sale GetSale(long id)
        {
            throw new NotImplementedException();
        }
    }
}
