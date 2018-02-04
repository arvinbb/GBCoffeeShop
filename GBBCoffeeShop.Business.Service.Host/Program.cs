using System;
using System.ServiceModel;
using Topshelf;

namespace GBBCoffeeShop.Business.Service.Host
{
    public class CoffeeShopService 
    {
        public ServiceHost serviceHost = null;
        public CoffeeShopService()
        {            
        }
        
        // Start the Windows service.
        public void OnStart()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }

            serviceHost = new ServiceHost(new Service.CoffeeShopService());

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
                x.Service<CoffeeShopService>(s =>   
                {
                    s.ConstructUsing(name => new CoffeeShopService());  
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
