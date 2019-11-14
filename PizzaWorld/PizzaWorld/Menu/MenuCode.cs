﻿using System;
using System.Collections.Generic;
using System.Text;
using EasyConsoleCore;
using PizzaWorld.Pages;

namespace PizzaWorld
{
    class MenuCode : EasyConsoleCore.Program
    {
        public MenuCode() : base("Kundterminal", breadcrumbHeader: true)
        {
            AddPage(new LanguageMenu(this));
            AddPage(new MainMenu(this));
            AddPage(new IngredientsMenu(this));
            AddPage(new OrderListMenu(this));
            AddPage(new PayMenu(this));

            SetPage<LanguageMenu>();
        }
    }
}
