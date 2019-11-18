using System;
using System.Collections.Generic;
using System.Text;
using EasyConsoleCore;

namespace PizzaWorld.Pages
{
    class PayMenu : Page
    {
        EasyConsoleCore.Program program;
        public PayMenu(EasyConsoleCore.Program program)
                : base("Pay", program)
        {
            this.program = program;
        }
        public override void Display()
        {
            base.Display();
            ConsoleColor.Yellow.WriteLine("PAYMENT:");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Order number: {ShoppingCart.orderDetails[0].orderNr}" + " " + " " + " " + " " + "Total price: " + ShoppingCart.CountTotalSum() + ":-");
            Console.WriteLine("--------------------------------------------------");
            ConsoleColor.Red.Write("PIN: ");

            string pass = "";
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                // Backspace Should Not Work
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    ConsoleColor.Red.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        program.NavigateTo<Receipt>();
                    }
                }
            } while (true);
        }
    }
}
