using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaWorld
{
    class MenuItems
    {
        public string name;
        public int totalPrice;
        public double moms = 0.12;
        public List<string> items = new List<string>();

        public MenuItems(List<string> items, string name, int pricePerItem)
        {
            this.items = items;
            this.name = name;
            this.totalPrice = pricePerItem * items.Count;
        }
    }
}
