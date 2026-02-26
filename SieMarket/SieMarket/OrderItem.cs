using System;
using System.Collections.Generic;
using System.Text;

namespace SieMarket
{
    public sealed class OrderItem
    {
        public string ProductName { get; }
        public int Quantity { get; }
        public decimal UnitPriceAtPurchase { get; }

        public OrderItem(string productName, int quantity, decimal unitPriceAtPurchase)
        {
            if (quantity<1 || unitPriceAtPurchase<0)
            {
                throw new ArgumentOutOfRangeException("Quantity or price value is invalid.");
            }
            if(string.IsNullOrWhiteSpace(productName))
            {
                throw new ArgumentException("Product name cannot be empty.");
            }
            ProductName = productName.Trim();
            Quantity = quantity;
            UnitPriceAtPurchase = unitPriceAtPurchase;
        }

        public decimal LineTotal => Quantity * UnitPriceAtPurchase;
    }
}
