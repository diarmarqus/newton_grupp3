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
        private MenuItems _orderItem = new MenuItems(null, null);
        public int orderNr { get; set; }
        public int qty { get { return _qty; } set { _qty = value; price = _orderItem.totalPrice * _qty; } }
        public int price { get; set; }
        public double totalSum { get; set; }
        public MenuItems orderItem { get; set; }

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
