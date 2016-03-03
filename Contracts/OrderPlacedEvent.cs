using System;
using Infrastructure.Common.ServiceBus;

namespace Contracts
{
    public class OrderPlacedEvent : IEvent
    {
        public DateTime When { get; set; }

        public OrderPlacedEvent(DateTime when)
        {
            When = when;
        }
    }
}