using System;
using Infrastructure.Common.IoC;
using Infrastructure.Common.ServiceBus;
using MassTransit;
using MassTransit.BusConfigurators;
using MassTransit.Transports.AzureServiceBus;

namespace Infrasctructure.MasstransitServiceBus
{
    public class MassTransitWithAzureServiceBusConfigurator
    {
        
        private readonly ServiceBusConfigurator _busConfigurator;

        public MassTransitWithAzureServiceBusConfigurator(string azureNamespace, string queueName, string azureServiceBusKey, ServiceBusConfigurator serviceBusConfigurator)
        {
            _busConfigurator = serviceBusConfigurator;
            CreateBus(azureNamespace, queueName, azureServiceBusKey);
        }

        public MassTransitWithAzureServiceBusConfigurator WithConcurrentConsumerLimit(int limit)
        {
            _busConfigurator.SetConcurrentConsumerLimit(limit);
            return this;
        }

        public MassTransitWithAzureServiceBusConfigurator WithHandler<TMessage, THandler>()
            where THandler : IHandle<TMessage>
                                                                                                  where TMessage:class
        {   
            _busConfigurator.Subscribe(subs =>
            {
                subs.Handler<TMessage>(msg => IoC.Resolve<THandler>().Handle(msg)).Permanent();
            });
            
            return this;
        }

        private void CreateBus(string azureNamespace, string queueName, string azureServiceBusKey)
        {   
            var queueUri = "azure-sb://" + azureNamespace + "/" + queueName;

            _busConfigurator.ReceiveFrom(queueUri);
            SetupAzureServiceBus(azureNamespace, azureServiceBusKey);
        }

        private void SetupAzureServiceBus(string azureNameSpace, string azureServiceBusKey)
        {
            _busConfigurator.UseAzureServiceBus(a => a.ConfigureNamespace(azureNameSpace, h =>
            {
                h.SetKeyName("RootManageSharedAccessKey");
                h.SetKey(azureServiceBusKey);
            }));
            _busConfigurator.UseAzureServiceBusRouting();
        }

    }
}
