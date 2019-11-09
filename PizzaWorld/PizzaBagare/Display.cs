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
        public void PrintTopInfo(string s = "Logga in")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------------");
            Console.WriteLine(s);
            Console.WriteLine("-----------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintBottomInfo(string s = "")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------------");
            if (string.IsNullOrWhiteSpace(s))
            {
                Console.WriteLine("# Välj order | 'L' logga ut");
            }
            else
            {
                Console.WriteLine("1. Sätt in i ugn");
                Console.WriteLine("2. Klar");
                Console.WriteLine("3. Tillbaka");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintOrders(List<Order> orders)
        {
            Console.WriteLine("#   | Ordernumber | Status");

            for (int i = 0; i < orders.Count; i++)
            {
                Console.WriteLine(string.Format("#{0,-2} | {1,-11} | {2}", i + 1, orders[i].OrderNumber, orders[i].Status.GetDescription()));
            }

            for (int i = 12; i > orders.Count; i--)
            {
                Console.WriteLine("#   |             |");
            }
        }

        public void PrintOrderDetails(Order order)
        {
            PrintTopInfo("Order #" + order.OrderNumber);

            Console.WriteLine("Pizza:");
            foreach (Pizza pizza in order.Pizzas)
            {
                PrintPizza(pizza);
            }

            Console.WriteLine("Tillbehör:");
            foreach (Extra extra in order.Extras)
            {
                Console.WriteLine($"- {extra.Item} {extra.Size}");
            }

            for (int i = 11; i > order.Pizzas.Count + order.Extras.Count; i--)
            {
                Console.WriteLine();
            }
        }

        private void PrintPizza(Pizza pizza)
        {
            if (pizza.Ingredients == null)
            {
                Console.WriteLine($"- {pizza.Name} {pizza.Size} {pizza.Crust}");
            }
            else
            {
                Console.Write($"- {pizza.Name} (");
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
