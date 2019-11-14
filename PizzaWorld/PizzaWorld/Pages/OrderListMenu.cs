using System;
using System.Collections.Generic;
using System.Text;
using EasyConsoleCore;

namespace PizzaWorld.Pages
{
    class OrderListMenu : Page
    {
        public OrderListMenu(EasyConsoleCore.Program program)
                : base("Order list", program)
        {

        }
        public override void Display()
        {

            int input;
            while (true)
            {
                base.Display();
                Console.WriteLine("1. OrderListMenu");


                input = Input.ReadInt("Please enter an integer (between 1 and 10):", min: 1, max: 10);
                if (input == 1)
                {
                    //program.NavigateTo<OrderListMenu>();
                }
                Console.Clear();
            }
        }
    }
}
