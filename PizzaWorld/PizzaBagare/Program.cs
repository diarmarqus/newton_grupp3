using System;

namespace PizzaBagare
{
    /// <summary>
    /// PizzaBagare Terminal
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Data data = new Data();
            Display display = new Display();
            Terminal terminal = new Terminal();

            terminal.LogIn(data, display);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Logged in as: " + terminal.Chef.Name);
                terminal.GetOrders(display);

                int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out int index);

                Console.Clear();
                terminal.GetOrderDetails(display, index);
                Console.ReadKey(true);
            }
        }
    }
}
    