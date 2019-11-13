using System;
using System.Collections.Generic;
using System.Text;

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

                Console.Write(string.Format(
                    " #{0,-2} | {1,-6} | {2}", 
                    i + 1, 
                    order.OrderNumber, 
                    order.Status.GetDescription()));

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
            //Console.WriteLine(orders.Count.ToString());
        }

        public void PrintOrderDetails(Order order)
        {
            Console.Clear();
            PrintTopInfo("Order #" + order.OrderNumber);

            Console.WriteLine(" Pizza:");
            foreach (Pizza pizza in order.Pizzas)
            {
                PrintPizza(pizza);
            }

            Console.WriteLine("\n Tillbehör:");
            foreach (Extra extra in order.Extras)
            {
                Console.WriteLine($" - {extra.Item} {extra.Size}");
            }

            for (int i = 6; i > order.Pizzas.Count + order.Extras.Count; i--)
            {
                Console.WriteLine();
            }

            Console.WriteLine("Status: " + order.Status.GetDescription());
        }

        public void PrintOrderNumber(Order order)
        {
            PrintTopInfo("Utskrift");
            Console.WriteLine("Skriver ut ordernummer " + order.OrderNumber + "...");
        }

        private void PrintPizza(Pizza pizza)
        {
            if (pizza.Ingredients == null)
            {
                Console.WriteLine($" - {pizza.Name} {pizza.Size} {pizza.Crust}");
            }
            else
            {
                Console.Write($" - {pizza.Name} (");
                PrintIngredients(pizza);
                Console.WriteLine($") {pizza.Size} {pizza.Crust}");
            }
        }

        private void PrintIngredients(Pizza pizza)
        {
            foreach (string ingredient in pizza.Ingredients)
            {
                Console.Write(ingredient);
                if (pizza.Ingredients.IndexOf(ingredient) != pizza.Ingredients.Count - 1)
                {
                    Console.Write(", ");
                }
            }
        }
    }
}
