using System;
using Contracts;
using Infrastructure.Common.ServiceBus;

namespace TestSubscriber.AppService
{
    public class SecondsubscriptionForOrderPlaced : IHandle<OrderPlacedEvent>
    {
        public void Handle(OrderPlacedEvent message)
        {
            Console.WriteLine("2nd handler for OrderPlaced " + message.When.ToLongTimeString());
        }
    }
}