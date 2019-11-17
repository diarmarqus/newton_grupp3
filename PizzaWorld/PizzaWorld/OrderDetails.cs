using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaWorld
{
    /// <summary>
    /// Contains info on individual order items
    /// 
    /// </summary>
    public class OrderDetails
    {
        int _qty;
        public int orderNr;
        public int qty { get { return _qty; } set { _qty = value; price = orderItem.totalPrice * _qty; } }
        public int price;
        public double totalSum;
        public MenuItems orderItem = new MenuItems(null, null);

        public OrderDetails(MenuItems orderItem)
        {
            Random random = new Random();
            this.orderNr = random.Next(1, 100);
            this.qty = 1;
            this.orderItem = orderItem;
            this.price = orderItem.totalPrice * qty;
        }
    }
}
