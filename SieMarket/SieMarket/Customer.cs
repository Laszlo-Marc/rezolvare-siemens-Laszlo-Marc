using System;
using System.Collections.Generic;
using System.Text;

namespace SieMarket
{
    public sealed class Customer
    {
        public string Name { get; }

        public Customer(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.");

            Name = name;
        }
    }
}
