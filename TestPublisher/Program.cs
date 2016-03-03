using Contracts;
using System;
using System.Threading.Tasks;
using Infrastructure.Common.IoC;
using Infrastructure.Common.ServiceBus;
using TestPublisher.Main;

namespace TestPublisher
{
    internal class Program
    {
        private static void Main(string[] args)
        {   
            Bootstrapper.Init();
            var serviceBus = IoC.Resolve<IServiceBus>();

            string text = "";

            while (text != "quit")
            {
                Console.Write("Enter number of messages to generate (quit to exit): ");
                text = Console.ReadLine();

                int numMessages = 0;
                if (int.TryParse(text, out numMessages) && numMessages > 0)
                {
                    Parallel.For(0, numMessages, i =>
                    {
                        var message = new SomethingHappenedMessage()
                        {
                            What = "message " + i.ToString(),
                            When = DateTime.Now,
                        };
                        serviceBus.Publish(message);
                    });
                }
                else if (text != "quit")
                {
                    Console.WriteLine("\"" + text + "\" is not a number.");
                }
            }
            serviceBus.Dispose();
        }
    }
}
