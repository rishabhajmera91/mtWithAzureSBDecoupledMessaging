using System.Configuration;
using Contracts;
using Infrasctructure.MasstransitServiceBus;
using Infrastructure.Common.IoC;
using Infrastructure.Common.ServiceBus;
using Infrastructure.UnityContainer;
using TestSubscriber.AppService;

namespace TestSubscriber.Main
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
            var bus = new MassTransitServiceBus(
                x =>
                    new MassTransitWithAzureServiceBusConfigurator(
                        ConfigurationManager.AppSettings.Get("azure-namespace"), "TestSubscriber",
                        ConfigurationManager.AppSettings.Get("azure-key"), x)
                        .WithHandler<SomethingHappened, SomethingHappenedHandler>());
                                                          
            ;
            IoC.RegisterInstance<IServiceBus>(bus);
        }

        private static void SetContainer()
        {
            IoC.SetContainer(new UnityIocContainer());
        }
    }
}
