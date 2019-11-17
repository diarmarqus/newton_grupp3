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

                Menu.DisplayPizzas(0, b);
                Console.WriteLine(b+1 + ". Go to checkout "  + Menu.numberOfPizzas);
                Console.WriteLine("nr of orders: " + ShoppingCart.orderDetails.Count);
                input = Input.ReadInt("Please enter an integer:", 0, b+1);
                if (input >= 0 && input <= b)
                {
                    // stores the choosen pizza in workingOrderDetails
                    ShoppingCart.workingOrderDetails = new OrderDetails(Menu.standardPizza[input]);
                    // Goes to the ingredients page to buy extras or change ingredients
                    program.NavigateTo<IngredientsMenu>(); 
                } else if (input == b+1){
                    program.NavigateTo<OrderListMenu>();
                }
                Console.Clear();
            }
        }
    }
}
