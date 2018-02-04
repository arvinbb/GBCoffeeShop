using GBBCoffeeShop.Business.Interfaces;
using GBBCoffeeShop.Common;
using GBBCoffeeShop.WebApi.Services;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace GBBCoffeeShop.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all components with the container here              
            container.RegisterInstance<LoggingService>(LoggingService.Log);
            container.RegisterType<ICoffeeShopService, CoffeeShopFacadeService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}