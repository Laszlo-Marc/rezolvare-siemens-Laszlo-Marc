using System;
using System.Collections.Generic;
using System.Text;

namespace SieMarket
{
    public static class StoreService
    {
        public static string FindTopSpenderCustomerName(IEnumerable<Order> orders)
        {
            if (orders is null) throw new ArgumentNullException(nameof(orders));

            var list = orders.ToList();
            if (list.Count == 0) throw new ArgumentException("Orders collection cannot be empty.", nameof(orders));
            var customers = new Dictionary<string, decimal>();
          
            foreach (var order in list)
            {
                var name = order.Customer.Name;
                var price = order.FinalPrice();
                if (customers.ContainsKey(name))
                {
                    customers[name] += price;
                }
                else
                {
                    customers[name] = price;
                }
            }
            string biggestSpender = null;
            decimal maxPrice = decimal.MinValue;
            foreach (var customer in customers)
            {
                if (customer.Value > maxPrice)
                {
                    maxPrice = customer.Value;
                    biggestSpender = customer.Key;
                }
            }
            return biggestSpender;
        }
        public static IEnumerable<KeyValuePair<string, int>> GetPopularProducts(IEnumerable<Order> orders)
        {
            if (orders is null) throw new ArgumentNullException(nameof(orders));

            var result = new Dictionary<string, int>();

            foreach (var order in orders)
            {
                foreach (var item in order.Items)
                {
                    var name = item.ProductName;

                    if (result.ContainsKey(name))
                        result[name] += item.Quantity;
                    else
                        result[name] = item.Quantity;
                }
            }

            return result.OrderByDescending(p => p.Value);
        }
    }
}
