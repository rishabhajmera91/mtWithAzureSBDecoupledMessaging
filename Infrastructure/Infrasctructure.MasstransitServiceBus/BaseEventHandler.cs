using System;
using Infrastructure.Common.ServiceBus;

namespace Infrasctructure.MasstransitServiceBus
{
    public class BaseEventHandler : IHandle<IEvent>
    {
        public void Handle(IEvent message)
        {
            Console.WriteLine("This is from the base event handler");
        }
    }
}