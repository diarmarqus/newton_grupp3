using System;
using System.Collections.Generic;
using System.Text;
using EasyConsoleCore;

namespace PizzaWorld.Pages
{
    class IngredientsMenu : Page
    {
        EasyConsoleCore.Program program;
        public IngredientsMenu(EasyConsoleCore.Program program)
                : base("Ingredients menu", program)

        {
            this.program = program;
        }
        public override void Display()
        {
            base.Display();
            ExtrasMenuCode iMenu = new ExtrasMenuCode();
            List<string> basePizza = new List<string>();
            basePizza.Add("American");
            basePizza.Add("Italian");
            iMenu.AddRow("Välj Bas.", basePizza, true);
            List<string> ingredients = new List<string>(Menu.ingredients);
            iMenu.AddRow("Choose Ingredients:", Menu.ingredients, false);

            iMenu.CheckAllIngredients(Menu.pizzaNr[ShoppingCart.workingOrderDetails.orderItem.menuNr]);
        
            iMenu.AddRow("Choose Drinks:", Menu.drinks, false);
            iMenu.AddRow("Choose Sallad:", Menu.sallad, false);
            iMenu.AddRow("Choose Sauce:", Menu.sauce, false);

            while (iMenu.Run())
            {
                System.Console.Clear();
                base.Display();
            }

            // loop through all menus and add to shopping cart
            for (int i = 0; i < iMenu.numberOfRows-1; i++)
            {
                ShoppingCart.CreateOrder((pick_item)i, ShoppingCart.workingOrderDetails.orderItem.menuNr, iMenu.all_menus[i+1].checked_item);
            }


            program.NavigateTo<MainMenu>();
        }
    }
}
