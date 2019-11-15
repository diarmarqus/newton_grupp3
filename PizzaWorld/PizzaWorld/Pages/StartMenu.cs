using System;
using System.Collections.Generic;
using System.Text;
using EasyConsoleCore;

namespace PizzaWorld.Pages
{
    class StartMenu : Page
    {

        EasyConsoleCore.Program program;
        public StartMenu(EasyConsoleCore.Program program)
                : base("Welcome to Pizza Palatset", program)

         {
            this.program = program;
        }
        public override void Display()
        {

            ConsoleKey input;

            while (true)
            {
                base.Display();
                Console.WriteLine("Create a new order:");
                Console.WriteLine("\n");
                Console.WriteLine("Press Enter");
                input = Console.ReadKey().Key;

                if (input == ConsoleKey.Enter)
                {
                    program.NavigateTo<MainMenu>();
                } 
              
                Console.Clear();
            }
        }
    }
}
