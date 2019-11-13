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

        public Pizza(PizzaBase pBase) : base(List<string> items, string name, int pricePerItem)
        {
            this.pBase = pBase;
         

            this.
        }

    }
}
