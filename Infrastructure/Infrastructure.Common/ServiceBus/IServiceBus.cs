using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.ServiceBus
{
    public interface IServiceBus : IDisposable
    {
        void Publish(IEvent eventMessage);
        void Send(ICommand commandMessage);
    }
}
