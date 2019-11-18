using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaWorld
{
   public class MenuItems
    {
        public string _name;
        public int _menuNr;
        public int _totalPrice;
        public double _moms = 0.12;
        public List<string> _items = new List<string>();

        public string name { get { return _name; } set { _name = value; } }
        public int menuNr { get { return _menuNr; } set { _menuNr = value; } }
        public int totalPrice { get { return _totalPrice; } set { _totalPrice = value; } }
        public double moms { get { return _moms; } set { _moms = value; } } 
        public List<string> items { get { return _items; } set { _items = value; } }

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
