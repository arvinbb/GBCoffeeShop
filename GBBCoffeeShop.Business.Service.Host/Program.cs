using CommonServiceLocator;
using GBBCoffeeShop.Business.Interfaces;
using GBBCoffeeShop.DataAccess.EntityFramework;
using GBBCoffeeShop.DataAccess.EntityFramework.Domain;
using GBBCoffeeShop.DataAccess.EntityFramework.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.ServiceModel;
using Topshelf;
using Unity;
using Unity.ServiceLocation;

namespace GBBCoffeeShop.Business.Service.Host
{
    public class CoffeeShopWinService 
    {
        public ServiceHost serviceHost = null;
        public CoffeeShopWinService()
        {
            SetupServiceLocator();
        }

        /// <summary>
        /// Setup the common service locator
        /// </summary>
        private void SetupServiceLocator()
        {
            UnityServiceLocator locator = new UnityServiceLocator(ConfigureUnityContainer());
            ServiceLocator.SetLocatorProvider(() => locator);
        }

        /// <summary>
        /// Configure the Unity DI container
        /// </summary>
        /// <returns></returns>
        private IUnityContainer ConfigureUnityContainer()
        {
            UnityContainer container = new UnityContainer();            
            CoffeeContext context = CoffeeContext.GetContext();

            // Seed the EntityFramework In-Memory database with values
            context.SeedData();
            
            container.RegisterInstance<CoffeeContext>(context);
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<ICoffeeShopService, CoffeeShopService>();
            
            return container;
        }

        // Start the Windows service.
        public void OnStart()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }

            var coffeeShopService = ServiceLocator.Current.GetInstance<ICoffeeShopService>();
            serviceHost = new ServiceHost(coffeeShopService);

            // Open the ServiceHostBase to create listeners and start 
            // listening for messages.
            serviceHost.Open();
        }

        public void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }

    }

    public class Program
    {
        public static void Main()
        {
            var rc = HostFactory.Run(x =>                                   
            {
                x.Service<CoffeeShopWinService>(s =>   
                {
                    s.ConstructUsing(name => new CoffeeShopWinService());  
                    s.WhenStarted(tc => tc.OnStart());        
                    s.WhenStopped(tc => tc.OnStop());     
                });
                x.RunAsLocalSystem();   

                x.SetDescription("GB Coffee Shop Service Host");    
                x.SetDisplayName("GB Coffee Shop Service");   
                x.SetServiceName("GBCoffeeShopService");   
            });  

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());  
            Environment.ExitCode = exitCode;
        }
    }

}
