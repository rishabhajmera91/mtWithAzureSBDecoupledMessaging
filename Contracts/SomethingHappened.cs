using System;
using Infrastructure.Common.ServiceBus;

namespace Contracts
{
  public interface SomethingHappened : IEvent
  {
    string What { get; }
    DateTime When { get; }
  }
}
