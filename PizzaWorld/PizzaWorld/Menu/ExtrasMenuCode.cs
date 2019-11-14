﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyConsole;

namespace PizzaWorld
{
    enum alphabet
    {
        a = 0, b = 1, c = 2, d = 3, e = 4, f = 5, g = 6, h = 7, i = 8, j = 9, k = 10,
        l = 11, m = 12, n = 13, o = 15, p = 16, q = 17, r = 18, s = 19, t = 20, u = 21,
        v = 21, x = 22, y = 23, z = 24
    }
    struct bar_menu
    {
        public List<string> menu;
        public bool[] checked_item;
        public bool radio_or_not;
        public string category;
        public bar_menu(string category, List<string> menu, bool radio_or_not)
        {
            this.category = category;
            this.menu = menu;
            this.radio_or_not = radio_or_not;
            checked_item = new bool[menu.Count];
            for (int i = 0; i < menu.Count; i++)
            {
                checked_item[i] = false;
            }
        }
    }
    public class ExtrasMenuCode
    {
        List<bar_menu> all_menus;
        int choosen_row;
        int numberOfRows;

        public ExtrasMenuCode()
        {
            all_menus = new List<bar_menu>();
            numberOfRows = 0;
            choosen_row = 0;
        }
        public void AddRow(string name, List<string> menu_row, bool radio_or_not)
        {
            all_menus.Add(new bar_menu(name, menu_row, radio_or_not));
            numberOfRows++;
        }
        public void CheckAllIngredients(List<int> allNr)
        {
            for (int i = 0; i < allNr.Count; i++)
            {
                all_menus[1].checked_item[allNr[i]] = true;
            }
        }
        public bool CheckItem(int nr)
        {
            if (nr < 0 && nr > numberOfRows) return false;
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
        private void PrintMenu()
        {
            for (int i = 0; i < all_menus.Count; i++)
            {
                List<string> pMenu = all_menus[i].menu;
                if (choosen_row == i) Console.Write(">");
                Console.WriteLine($"{i}. {all_menus[i].category}");
                Console.Write("\t");
                for (int j = 0; j < pMenu.Count; j++)
                {
                    char check;
                    check = (all_menus[i].checked_item[j] == true) ? '*' : ' ';
                    if (choosen_row == i)
                    {
                        Console.Write($"{((alphabet)j).ToString()}.{check}{pMenu[j]}");
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

        public bool Run()
        {
            char input;
            int input_value;
            PrintMenu();
            input = Console.ReadKey().KeyChar;
            if (char.IsDigit(input))
            {
                input_value = Int32.Parse(input.ToString());
                if (input_value >= 0 && input_value <= numberOfRows)
                {
                    choosen_row = input_value;

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
            else
            {
                Console.WriteLine(input + " is not a valid input");
            }
            return true;
        }
    }
}