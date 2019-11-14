using System;
using System.Collections.Generic;
using System.Text;
using EasyConsole;

namespace PizzaWorld.Pages
{
    class LanguageMenu : Page
    {
        EasyConsole.Program program;
        public LanguageMenu(EasyConsole.Program program)
                : base("Input", program)

         {
            this.program = program;
        }
        public override void Display()
        {

            int input;

            while (true)
            {
                base.Display();
                Console.WriteLine("1. Svenska");
                Console.WriteLine("2. English");
                input = Input.ReadInt("Please enter an integer (between 1 and 2):", min: 1, max: 10);
                if (input == 1)
                {
                    program.NavigateTo<MainMenu>();
                } else if (input == 2)
                {
                    program.NavigateTo<MainMenu>();
                }
                Console.Clear();
            }
        }
}
}
