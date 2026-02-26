using System;
using System.Collections.Generic;

namespace SieMarket
{
    internal static class Program
    {
        private static void Main()
        {
            // Customers
            var ana = new Customer("Ana Popescu");
            var mihai = new Customer("Mihai Ionescu");

            // Orders
            var order1 = new Order(
                ana,
                new List<OrderItem>
                {
                    new OrderItem("Laptop", 2, 300m),
                    new OrderItem("Mouse", 1, 50m),
                }
            );

           
            var order2 = new Order(
                ana,
                new List<OrderItem>
                {
                    new OrderItem("Monitor", 1, 120m),
                    new OrderItem("Keyboard", 2, 40m),
                }
            );

           
            var order3 = new Order(
                mihai,
                new List<OrderItem>
                {
                    new OrderItem("Headphones", 4, 100m),
                    new OrderItem("Mouse", 1, 90m),
                }
            );

           
            var order4 = new Order(
                mihai,
                new List<OrderItem>
                {
                    new OrderItem("Phone", 1, 600m),
                }
            );

            var allOrders = new List<Order> { order1, order2, order3, order4 };


            Console.WriteLine("=== Order totals (2.2) ===");
            PrintOrder(order1);
            PrintOrder(order2);
            PrintOrder(order3);
            PrintOrder(order4);

            //Methods
            Console.WriteLine();
            Console.WriteLine("=== Top spender (2.3) ===");
            var topSpender = StoreService.FindTopSpenderCustomerName(allOrders);
            Console.WriteLine($"Top spender: {topSpender}");

            Console.WriteLine();
            Console.WriteLine("=== Popular products (2.4) ===");
            var popular = StoreService.GetPopularProducts(allOrders);
            foreach (var kvp in popular)
            {
                Console.WriteLine($"{kvp.Key}: total quantity sold = {kvp.Value}");
            }

            Console.WriteLine();
            Console.WriteLine("=== Sanity checks ===");
            Console.WriteLine("Ana totals: order1 final 585, order2 final 200 => 785");
            Console.WriteLine("Mihai totals: order3 final 490, order4 final 540 => 1030");
            Console.WriteLine("So top spender should be Mihai Ionescu.");
        }

        private static void PrintOrder(Order order)
        {
            var before = order.TotalBeforeDiscount();
            var final = order.FinalPrice();
            var discountApplied = before > 500m;

            Console.WriteLine($"Customer: {order.Customer.Name}");
            Console.WriteLine($"  Total before discount: {before:0.00} EUR");
            Console.WriteLine($"  Discount applied: {(discountApplied ? "YES (10%)" : "NO")}");
            Console.WriteLine($"  Final price: {final:0.00} EUR");
        }
    }
}