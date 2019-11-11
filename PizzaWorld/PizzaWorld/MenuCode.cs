using System;
using System.Collections.Generic;
using System.Text;
using EasyConsole;
using PizzaWorld.Pages;

namespace PizzaWorld
{
    class MenuCode : EasyConsole.Program
    {
        public MenuCode() : base("Kundterminal", breadcrumbHeader: true)
        {
            AddPage(new MainPage(this));
            AddPage(new Page1(this));

            SetPage<MainPage>();
        }
    }
}
