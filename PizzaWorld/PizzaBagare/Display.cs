using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBagare
{
    class Display
    {
        public void PrintLogInInfo(string s = "")
        {
            Console.Clear();
            Console.WriteLine("PizzaBagare Terminal");
            Console.WriteLine("--------------------");
            if (!string.IsNullOrWhiteSpace(s))
            {
                Console.WriteLine(s);
            }
        }

        public void PrintOrders(List<Order> orders)
        {
            Console.WriteLine("#     Order#");
            for (int i = 0; i < orders.Count; i++)
            {
                Console.WriteLine($"#{i + 1}    {orders[i].OrderNumber} ----");
            }
        }

        public void PrintOrderDetails(Order order)
        {
            Console.WriteLine($"#{order.OrderNumber} ----");
            foreach (Pizza pizza in order.Pizzas)
            {
                PrintPizza(pizza);
            }

            foreach (Extra extra in order.Extras)
            {
                Console.WriteLine($"{extra.Item} {extra.Size}");
            }
        }

        private void PrintPizza(Pizza pizza)
        {
            if (pizza.Ingredients == null)
            {
                Console.WriteLine($"{pizza.Name} {pizza.Size} {pizza.Crust}");
            }
            else
            {
                Console.Write($"{pizza.Name} (");
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
