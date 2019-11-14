using System;
using System.Collections.Generic;
using System.Text;
using EasyConsole;

namespace PizzaWorld.Pages
{
    class MainMenu : Page
    {
        EasyConsole.Program program;
        int a = 0, amountOfListedItems = 5;
        public MainMenu(EasyConsole.Program program)
            : base("Main Menu", program)
        {
            this.program = program;
        }
        public override void Display()
        {
            Menu menu = new Menu();
            int input;
            while (true)
            {

                int b = a + amountOfListedItems;
                base.Display();
                menu.DisplayPizzas(a, b);
                Console.WriteLine($"{b + 1}. Own Choice");
                Console.WriteLine($"{b + 2}. Go Forward");
                Console.WriteLine($"{b + 3}. Go Backward");
                input = Input.ReadInt("Please enter an integer:", a, b+3);
                if (input >= a && input <= b+1)
                {
                    ShoppingCart.workingOrderDetails = new OrderDetails(ShoppingCart.menu.standardPizza[input]);
                    program.NavigateTo<IngredientsMenu>();
                }
                else if (input == b+2)
                {
                    a += amountOfListedItems;
                } else if (input == b+3)
                {
                    a -= amountOfListedItems;
                }
                Console.Clear();
            }
        }
    }
}
