using System;
using System.Threading;
using System.Threading.Tasks;
using Contracts;
using Infrastructure.Common.ServiceBus;

namespace TestSubscriber.AppService
{
  public class SomethingHappenedHandler : IHandle<SomethingHappened>
  {
      public void Handle(SomethingHappened message)
      {
          Console.WriteLine("FROM HANDLE METHOD" +
                       "TXT: " + message.What +
                       "  SENT: " + message.When.ToString() +
                       "  PROCESSED: " + DateTime.Now.ToString() +
                       " (" + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString() + ")");

          // Simulate processing time
          Thread.Sleep(250);
      }
  }
}
