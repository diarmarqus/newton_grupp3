using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyConsoleCore;

/// <summary>
/// Menykoden för tillbehörssidan
/// 
/// </summary>

namespace PizzaWorld
{
    /// <summary>
    /// A struct to collect the data of every row
    /// menu            contains all the items
    /// category        the name of the row
    /// checked_item    is to have a list of the position of every checked_item
    /// </summary>
    public struct bar_menu
    {
        public List<string> menu;
        public bool[] checked_item;
        public bool radio_or_not;
        public string category;
        public int numberOfItems;

        public bar_menu(string category, List<string> menu, bool radio_or_not)
        {
            numberOfItems = menu.Count;
            this.category = category;
            this.menu = menu;
            this.radio_or_not = radio_or_not;
            checked_item = new bool[numberOfItems];
            for (int i = 0; i < menu.Count; i++)
            {
                checked_item[i] = false;
            }
        }
    }
    public class ExtrasMenuCode
    {
        public List<bar_menu> all_menus { get; set; }
        public int numberOfRows { get; set; }
        int choosen_row;
        

        public ExtrasMenuCode()
        {
            all_menus = new List<bar_menu>();
            numberOfRows = 0;
            choosen_row = 0;
        }
        /// <summary>
        /// Lägger till en menyrad med ett kategorinamn, och en lista med alla objekt
        /// </summary>
        /// <param name="name">Name for the category</param>
        /// <param name="menu_row">List of items</param>
        /// <param name="radio_or_not">If the list is radiobuttons or not</param>
        
        public void AddRow(string name, List<string> menu_row, bool radio_or_not)
        {
            all_menus.Add(new bar_menu(name, menu_row, radio_or_not));
            numberOfRows++;
        }
        /// <summary>
        /// Checks all the ingredients in the choosen pizza
        /// Stores it in checked_item
        /// </summary>
        /// <param name="allNr">A list on all the ingredients to check</param>

        public void CheckAllIngredients(List<int> allNr)
        {
            for (int i = 0; i < allNr.Count; i++)
            {
                all_menus[1].checked_item[allNr[i]] = true;
            }
        }

        /// <summary>
        /// Takes a number and checks that position in the bool array checked_item
        /// </summary>
        /// <param name="nr">Position to check the item in checked_item</param>
        /// <returns></returns>
        public bool CheckItem(int nr)
        {
            if (nr < 0 || nr >= all_menus[choosen_row].numberOfItems) return false;
            if (all_menus[choosen_row].radio_or_not == false)
            {
                if (all_menus[choosen_row].checked_item[nr] == false)
                    all_menus[choosen_row].checked_item[nr] = true;
                else
                    all_menus[choosen_row].checked_item[nr] = false;
            }
            else
            {
                for (int i = 0; i < all_menus[choosen_row].menu.Count; i++)
                {
                    all_menus[choosen_row].checked_item[i] = false;
                }
                all_menus[choosen_row].checked_item[nr] = true;
            }
            return true;
        }

        /// <summary>
        /// Just prints all the menus in order
        /// </summary>
        private void PrintMenu()
        {
            Console.WriteLine(ShoppingCart.workingOrderDetails.orderItem.name);
            for (int i = 0; i < all_menus.Count; i++)
            {
                List<string> pMenu = all_menus[i].menu;
                if (choosen_row == i) ConsoleColor.Red.Write(">");
                Console.WriteLine($"{i}. {all_menus[i].category}");
                Console.Write("\t");
                for (int j = 0; j < pMenu.Count; j++)
                {
                    char check;
                    check = (all_menus[i].checked_item[j] == true) ? '*' : ' ';
                    if (choosen_row == i)
                    {
                        if (all_menus[i].checked_item[j] == true)
                        {
                            ConsoleColor.Green.Write($"{(char)(j+97)}.{check}{pMenu[j]}");
                        }
                        else
                        {
                            Console.Write($"{(char)(j + 97)}.{check}{pMenu[j]}");
                        }
                        
                    }
                    else
                    {
                        Console.Write($"{check}{pMenu[j]}");
                    }
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }


        /// <summary>
        /// Makes the menu run
        /// Reads an input from user
        /// Numbers to change category and letters to check items
        /// 
        /// </summary>
        /// <returns>If the menu shall continue or not</returns>
        public bool Run()
        {
            char input;
            int input_value;
            PrintMenu();
            Console.Write("Choose an option(1-4 for category, a-z for items and Enter to accept)\n:");

            input = Console.ReadKey().KeyChar;
            if (char.IsDigit(input))
            {
                input_value = Int32.Parse(input.ToString());
                if (input_value >= 0 && input_value <= numberOfRows)
                {
                    choosen_row = input_value;          // saves the marked category
                }
                else
                {
                    Console.WriteLine(input + " is not a valid input");
                }
            }
            else if (char.IsLetter(input))
            {
                input = char.ToLower(input);
                input_value = (int)input - 97;
                Console.WriteLine(input + " ds " + input_value);

                if (CheckItem(input_value) == false)
                {
                    Console.WriteLine(input + " is not a valid input");
                }
            } 
            else if (input == '\r')
            {
                Console.Write("Accept items(y,n)?");
                input = Console.ReadKey().KeyChar;
                if (input == 'y')
                {
                    return false;
                }
            } else
            {
                Console.WriteLine(input + " is not a valid input");
            }
            return true;
        }
    }
}
