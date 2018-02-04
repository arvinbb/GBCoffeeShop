using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using GBBCoffeeShop.Business.Entities;

namespace GBBCoffeeShop.Business.Interfaces
{

    /// <summary>
    /// Defines the service contract
    /// </summary>
    [ServiceContract(Namespace = "http://GBBCoffeeShop.com")]
    public interface ICoffeeShopService
    {
        [OperationContract]
        Sale GetSale(long id);        
    }
}
