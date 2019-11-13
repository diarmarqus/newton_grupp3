using System;
using System.Media;

namespace PizzaBagare
{
    /// <summary>
    /// PizzaBagare Terminal
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "PizzaBagare Terminal";

            Data data = new Data();
            Display display = new Display();
            Terminal terminal = new Terminal();

            while (true)
            {
                terminal.Start(data, display);
            }
        }
    }
}
    