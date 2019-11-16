using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaWorld
{
    public class ExtraMenu:MenuItems
    {
        int pricePerItem;
      
        public ExtraMenu(List<string> items, string name, int pricePerItem) : base(items, name)
        {
            base.totalPrice = items.Count * pricePerItem;
        }
    }
}
