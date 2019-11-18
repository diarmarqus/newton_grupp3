using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaWorld
{
    

    public class Pizza : MenuItems
    {
        private string pBase;
        private int pricePerItem = 20;

        public Pizza(string pBase, List<string> items, string name, int menuNr) : base(items, name, menuNr)
        {
            this.pBase = pBase;
            base.totalPrice = items.Count * pricePerItem;
        }
    }
}
