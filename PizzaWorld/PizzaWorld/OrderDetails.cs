using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaWorld
{
    public class OrderDetails
    {
        private int orderNr;
        public int qty;
        public int price;
        private int totalSum;
        public MenuItems orderItem;


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
