using Infrastructure.Common.IoC;
using Infrastructure.Common.ServiceBus;
using System;
using TestSubscriber.Main;

namespace TestSubscriber
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Bootstrapper.Init();

            Console.ReadKey();

            IoC.Resolve<IServiceBus>().Dispose();
        }
    }
}
