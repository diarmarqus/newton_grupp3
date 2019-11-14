using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaWorld
{
    public enum PizzaBase
    {
        Italian = 0,
        American = 1
    }

    public class Pizza : MenuItems
    {
        private PizzaBase pBase;
        int pricePerItem = 20;

        public Pizza(PizzaBase pBase, List<string> items, string name, int menuNr) : base(items, name, menuNr)
        {
            this.pBase = pBase;
            base.totalPrice = items.Count * pricePerItem;
        }
    }
}
