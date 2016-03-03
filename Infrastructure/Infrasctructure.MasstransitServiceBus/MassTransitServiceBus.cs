using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Common.ServiceBus;
using MassTransit;
using MassTransit.BusConfigurators;
using MassTransit.Log4NetIntegration.Logging;
using MassTransit.Transports.AzureServiceBus;
using IServiceBus = Infrastructure.Common.ServiceBus.IServiceBus;

namespace Infrasctructure.MasstransitServiceBus
{
    public class MassTransitServiceBus : IServiceBus
    {
        private readonly MassTransit.IServiceBus _massTransitBus;


        public MassTransitServiceBus(Action<ServiceBusConfigurator> configurator)
        {
            Log4NetLogger.Use();
            _massTransitBus = ServiceBusFactory.New(sbc => configurator(sbc));
        }

        public void Publish(IEvent eventMessage)
        {
            _massTransitBus.Publish(eventMessage, eventMessage.GetType(), x => { x.SetDeliveryMode(MassTransit.DeliveryMode.Persistent); });
        }

        public void Send(ICommand commandMessage)
        {
            _massTransitBus.Publish(commandMessage, commandMessage.GetType(), x => { x.SetDeliveryMode(MassTransit.DeliveryMode.Persistent); });
        }

        public void Dispose()
        {
            _massTransitBus.Dispose();
        }
    }
}
