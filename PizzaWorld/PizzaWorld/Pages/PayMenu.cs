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
            
            while (true)
            {
                base.Display();
                Console.WriteLine($"Order number: {ShoppingCart.orderDetails[0].orderNr}" + " " + " " + " " + " " + "Total price: " + ShoppingCart.CountTotalSum() + ":-");
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("Ange Pinkod:" );
                var pin = Console.ReadLine();
                if (pin == "0000")
                {
                    program.NavigateTo<Receipt>();
                }
                Console.Clear();
            }
            
        }
    }
}
