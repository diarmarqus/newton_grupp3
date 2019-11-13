using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaWorld
{
    enum PizzaBase
    {
        Italian = 0,
        American = 1
    }

    class Pizza : MenuItems
    {
        private PizzaBase pBase;
        int pricePerItem = 20;

        public Pizza(PizzaBase pBase, List<string> items, string name) : base(items, name)
        {
            this.pBase = pBase;
            base.totalPrice = items.Count * pricePerItem;
        }

    }
}
