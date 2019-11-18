using System;
using System.Collections.Generic;
using System.Text;
using EasyConsoleCore;

namespace PizzaWorld.Pages
{
    /// <summary>
    /// The page where a user can choose a pizza
    /// </summary>
    class MainMenu : Page
    {
        EasyConsoleCore.Program program;
        public MainMenu(EasyConsoleCore.Program program)
            : base("Main Menu", program)
        {
            this.program = program;
        }
        public override void Display()
        {
            int input;
            int b=Menu.numberOfPizzas-1;
            while (true)
            {
                base.Display();

                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\tNr of items: " + ShoppingCart.orderDetails.Count);

                Menu.DisplayPizzas(0, b);
                //Console.WriteLine("\n");
                Console.WriteLine("Go to checkout, press " +Menu.numberOfPizzas);
                //Console.WriteLine("\n");

                Console.Write("Please enter a number you want to choose:", 0, b + 1);

                while (true)
                {
                    if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out input))
                    {
                        break;
                    }
                }

                if (input >= 0 && input <= b)
                {
                    // stores the choosen pizza in workingOrderDetails
                    ShoppingCart.workingOrderDetails = new OrderDetails(Menu.standardPizza[input]);
                    // Goes to the ingredients page to buy extras or change ingredients
                    program.NavigateTo<IngredientsMenu>(); 
                } else if (input == b + 1)
                {
                    if (ShoppingCart.orderDetails.Count != 0)   // needs a order 
                        program.NavigateTo<OrderListMenu>();
                }
                Console.Clear();
            }
        }
    }
}
