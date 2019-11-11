using System;
using System.Collections.Generic;
using System.Text;
using EasyConsole;

namespace PizzaWorld.Pages
{
    class MainPage : MenuPage
    {
        public MainPage(EasyConsole.Program program)
            : base("Main Page", program,
                  new Option("Page 1", () => program.NavigateTo<Page1>()))
        {



        }
    }
}
