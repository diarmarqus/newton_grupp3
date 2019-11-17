using System;
using System.Collections.Generic;
using System.Text;
using EasyConsoleCore;

namespace PizzaWorld.Pages
{
    /// <summary>
    /// This is the menu page to choose ingredients
    /// and extras.
    /// Addrow() to add menu rows and Run() to display the menu
    /// </summary>
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
            iMenu.AddRow("Choose a crust.", basePizza, true);
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


            List<string> newItems = new List<string>();
            for (int i = 0; i < Menu.ingredients.Count; i++)
            {
                if (iMenu.all_menus[1].checked_item[i] == true)
                    newItems.Add(Menu.ingredients[i]);
            }
            ShoppingCart.workingOrderDetails.orderItem.items = new List<string>(newItems);
            ShoppingCart.addOrder(ShoppingCart.workingOrderDetails);
          
            for (int i = 0; i < 3; i++)
            {
                if (iMenu.all_menus[2].checked_item[i] == true)
                {
                    ExtraMenu em = new ExtraMenu(new List<string>() { Menu.drinks[i] }, Menu.drinks[i], 20);
                    ShoppingCart.addOrder(new OrderDetails(em));
                }
            }
            newItems = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                if (iMenu.all_menus[3].checked_item[i] == true)
                {
                    ExtraMenu em = new ExtraMenu(new List<string>() { Menu.sallad[i] }, Menu.sallad[i], 20);
                    ShoppingCart.addOrder(new OrderDetails(em));
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (iMenu.all_menus[3].checked_item[i] == true)
                {
                    ExtraMenu em = new ExtraMenu(new List<string>() { Menu.sauce[i] }, Menu.sauce[i], 20);
                    ShoppingCart.addOrder(new OrderDetails(em));
                }
            }

            program.NavigateBack();
        }
    }
}
