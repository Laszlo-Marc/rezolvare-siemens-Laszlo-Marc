using System;
using System.Collections.Generic;
using System.Text;

namespace SieMarket
{
    public sealed class Order
    {
        public Customer Customer { get; }
        public IReadOnlyList<OrderItem> Items { get; }

        public Order(Customer customer, IEnumerable<OrderItem> items)
        {
            Customer = customer ?? throw new ArgumentNullException(nameof(customer));

            if (items is null) throw new ArgumentNullException(nameof(items));

            var list = items.ToList();
            if (list.Count == 0) throw new ArgumentException("Order must contain at least one item.", nameof(items));

            Items = list;
        }
        public decimal TotalBeforeDiscount()
        {
            decimal total = 0m;

            foreach (var item in Items)
            {

                total += item.LineTotal;
            
            }

            return total;
        }
        public decimal FinalPrice()
        {
            var total = TotalBeforeDiscount();

           
            if (total > 500m)
            {
                return total * 0.90m; 
            }

            return total;
        }
    }
}
