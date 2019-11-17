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

                string banner =$" _    _      _                            _         ______ _                            _       _            _\n" +
                "| |  | |    | |                          | |        | ___ (_)                          | |     | |          | |\n" +
                "| |  | | ___| | ___ ___  _ __ ___   ___  | |_ ___   | |_/ /_ __________ _   _ __   __ _| | __ _| |_ ___  ___| |_\n" +
                "| |/\\| |/ _ \\ |/ __/ _ \\| '_ ` _ \\ / _ \\ | __/ _ \\  |  __/| |_  /_  / _` | | '_ \\ / _` | |/ _` | __/ __|/ _ \\ __|\n" +
                "\\  /\\  /  __/ | (_| (_) | | | | | |  __/ | || (_) | | |   | |/ / / / (_| | | |_) | (_| | | (_| | |_\\__ \\  __/ |_\n" +
                " \\/  \\/ \\___|_|\\___\\___/|_| |_| |_|\\___|  \\__\\___/  \\_|   |_/___/___\\__,_| | .__/ \\__,_|_|\\__,_|\\__|___/\\___|\\__|\n" +
                "                                                                           | |\n"+                                   
                "                                                                           |_| \n";                                  
                Console.WriteLine(banner);
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
