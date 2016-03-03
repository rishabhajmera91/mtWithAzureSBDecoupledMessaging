using Contracts;
using System;

namespace TestPublisher
{
    internal class SomethingHappenedMessage : SomethingHappened
    {
        public string What { get; set; }
        public DateTime When { get; set; }
    }
}
