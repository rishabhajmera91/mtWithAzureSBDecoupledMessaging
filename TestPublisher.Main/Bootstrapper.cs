using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Infrasctructure.MasstransitServiceBus;
using Infrastructure.Common.IoC;
using Infrastructure.Common.ServiceBus;
using Infrastructure.UnityContainer;

namespace TestPublisher.Main
{
    public class Bootstrapper
    {
        public static void Init()
        {
            SetContainer();

            RegisterServiceBus();
        }

        private static void RegisterServiceBus()
        {
            var bus = new MassTransitServiceBus(x => new MassTransitWithAzureServiceBusConfigurator(ConfigurationManager.AppSettings.Get("azure-namespace"), "TestPublisher", ConfigurationManager.AppSettings.Get("azure-key"), x));
            IoC.RegisterInstance<IServiceBus>(bus);
        }

        private static void SetContainer()
        {
            IoC.SetContainer(new UnityIocContainer());
        }
    }
}
