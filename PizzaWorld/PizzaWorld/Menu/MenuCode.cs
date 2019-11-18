using System;
using System.Collections.Generic;
using System.Text;
using EasyConsoleCore;
using PizzaWorld.Pages;

namespace PizzaWorld
{

    /// <summary>
    /// Contains all the pages in the terminal
    /// SetPage sets the start page
    /// </summary>
    class MenuCode : EasyConsoleCore.Program
    {
        public MenuCode() : base("Kundterminal", breadcrumbHeader: true)
        {
            AddPage(new StartMenu(this));
            AddPage(new MainMenu(this));
            AddPage(new IngredientsMenu(this));
            AddPage(new OrderListMenu(this));
            AddPage(new PayMenu(this));
            AddPage(new Receipt(this));

            SetPage<StartMenu>();
        }
    }
}
