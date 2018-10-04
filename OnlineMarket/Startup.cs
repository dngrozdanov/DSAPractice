using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Wintellect.PowerCollections;

namespace OnlineMarket
{
    static class Startup
    {
        static OrderedBag<Order> Orders = new OrderedBag<Order>();
        static Dictionary<string, OrderedBag<Order>> OrdersByConsumer = new Dictionary<string, OrderedBag<Order>>();

        static void Main()
        {
            try
            {
                int commandNum = int.Parse(Console.ReadLine());

                var strBuilder = new StringBuilder();

                for (int i = 0; i < commandNum; i++)
                {
                    var input = Console.ReadLine();
                    var command = input.Split()[0];
                    var args = input.Replace(command + " ", "").Split(new char[] { ';' });

                    if (command == "AddOrder")
                    {
                        var price = double.Parse(args[1]);
                        var message = AddOrder(args[0], args[2], price);
                        strBuilder.AppendLine(message);
                    }
                    else if (command == "FindOrdersByConsumer")
                    {
                        var message = FindOrdersByConsumer(args[0]);
                        strBuilder.AppendLine(message);
                    }
                    else if (command == "DeleteOrders")
                    {
                        var message = DeleteOrdersByConsumer(args[0]);
                        strBuilder.AppendLine(message);
                    }
                    else if (command == "FindOrdersByPriceRange")
                    {
                        double min = double.Parse(args[0]);
                        double max = double.Parse(args[1]);

                        string message = FindOrdersByPriceRange(min, max);
                        strBuilder.AppendLine(message);
                    }
                }

                Console.Write(strBuilder.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static string FindOrdersByPriceRange(double min, double max)
        {
            var products = Orders
                .Where(x => x.Price >= min && x.Price <= max).OrderBy(x => x.Name);

            if (!products.Any())
                return "No orders found";

            return string.Join(Environment.NewLine, products);
        }

        static string FindOrdersByConsumer(string consumer)
        {
            if (!OrdersByConsumer.ContainsKey(consumer))
            {
                return "No orders found";
            }

            if (!OrdersByConsumer[consumer].Any())
                return "No orders found";

            return string.Join(Environment.NewLine, OrdersByConsumer[consumer].OrderBy(x => x.Name));
        }

        static string DeleteOrdersByConsumer(string consumer)
        {
            if (!OrdersByConsumer.ContainsKey(consumer))
            {
                return "No orders found";
            }

            if (!OrdersByConsumer[consumer].Any())
                return "No orders found";

            var count = OrdersByConsumer[consumer].Count;
            OrdersByConsumer[consumer].Clear();
            Orders.RemoveAll(x => x.Name == consumer);

            return $"{count} orders deleted";
        }

        static string AddOrder(string name, string consumer, double price)
        {
            var newProduct = new Order(name, consumer, price);

            Orders.Add(newProduct);

            if (!OrdersByConsumer.ContainsKey(consumer))
            {
                OrdersByConsumer[consumer] = new OrderedBag<Order>();
            }

            OrdersByConsumer[consumer].Add(newProduct);

            return $"Order added";
        }

        public class Order : IComparable<Order>
        {
            public string Name { get; set; }
            public string Consumer { get; set; }
            public double Price { get; set; }

            public Order(string name, string consumer, double price)
            {
                Name = name ?? throw new ArgumentNullException(nameof(name));
                Consumer = consumer ?? throw new ArgumentNullException(nameof(consumer));
                Price = price;
            }

            public int CompareTo(Order other)
            {
                int comparison = this.Price.CompareTo(other.Price);

                return comparison;
            }

            public override string ToString()
            {
                return "{" + $"{this.Name};{this.Consumer};{this.Price:F2}" + "}";
            }
        }
    }
}