using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaWorld
{
   public class MenuItems
    {
        public string name;
        public int menuNr;
        public int totalPrice;
        public double moms = 0.12;
        public List<string> items = new List<string>();

        public MenuItems(List<string> items, string name, int menuNr)
        {
            this.items = items;
            this.name = name;
            this.menuNr = menuNr;
        }
        public MenuItems(List<string> items, string name)
        {
            this.items = items;
            this.name = name;
        }
    }
}
