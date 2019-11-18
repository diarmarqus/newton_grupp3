using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaWorld
{
    public class ExtraMenu:MenuItems
    {
        int _pricePerItem;
      
        public ExtraMenu(List<string> items, string name, int pricePerItem) : base(items, name)
        {
            _pricePerItem = pricePerItem;
            base.totalPrice = items.Count * pricePerItem;
        }
    }
}
