using System;
using Contracts;
using Infrastructure.Common.ServiceBus;

namespace TestSubscriber.AppService
{
    public class FirstSubscriptionForOrderPlaced : IHandle<OrderPlacedEvent>
    {
        public void Handle(OrderPlacedEvent message)
        {
            Console.WriteLine("1st handler for OrderPlaced " + message.When.ToLongTimeString());
        }
    }
}