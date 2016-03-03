using System;
using Contracts;
using Infrastructure.Common.ServiceBus;

namespace TestSubscriber.AppService
{
    public class ThirdHandler : IHandle<SomethingHappened>
    {
        public void Handle(SomethingHappened message)
        {
            Console.WriteLine("Third handler");
        }
    }
}