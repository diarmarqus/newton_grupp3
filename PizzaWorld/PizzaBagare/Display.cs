using System;
using System.Collections.Generic;

namespace PizzaBagare
{
    /// <summary>
    /// Hanterar utskrift av datan till konsollen
    /// </summary>
    class Display
    {
        public void PrintTopInfo(string s)
        {
            Console.Clear();
            ConsoleColor.Yellow.WriteLine("-----------------------");
            ConsoleColor.Yellow.WriteLine(s);
            ConsoleColor.Yellow.WriteLine("-----------------------");
        }

        public void PrintBottomInfo(bool IsOrderDetails)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------------");
            if (IsOrderDetails)
            {
                Console.WriteLine(" 1. Sätt in i ugn");
                Console.WriteLine(" 2. Slutförd");
                Console.WriteLine(" 3. Tillbaka");
            }
            else
            {
                Console.WriteLine(" # Välj order |'L'ogga ut");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintOrders(List<Order> orders)
        {
            Console.WriteLine(" #   | Order# | Status");
            int orderCount = 0;

            for (int i = 0; i < orders.Count; i++)
            {
                if (i >= 9)
                {
                    orderCount = i - 8;
                    continue;
                }

                var order = orders[i];

                Console.Write($" #{i + 1,-2} | {order.OrderNumber,-6} | {order.Status.GetDescription()}");

                if (order.Status == OrderStatus.Done)
                {
                    ConsoleColor.Red.WriteLine(" <<<");
                    continue;
                }

                Console.WriteLine();
            }

            for (int i = 9; i > orders.Count; i--)
            {
                Console.WriteLine(" #   |        |");
            }

            Console.WriteLine(orderCount > 0 ? $" +{orderCount} väntande" : null);
        }

        public void PrintOrderDetails(Order order)
        {
            Console.Clear();
            PrintTopInfo("Order #" + order.OrderNumber);

            Console.WriteLine(" Pizza:");
            Console.WriteLine(order.GetPizzas());

            Console.WriteLine("\n Tillbehör:");
            Console.WriteLine(order.GetExtras());

            for (int i = 6; i > order.Pizzas.Count + order.Extras.Count; i--)
            {
                Console.WriteLine();
            }

            Console.WriteLine("Status: " + order.Status.GetDescription());
        }

        public void PrintOrderNumber(Order order)
        {
            PrintTopInfo("Utskrift");
            Console.WriteLine($"Skriver ut ordernummer {order.OrderNumber}...");
        }
    }
}
