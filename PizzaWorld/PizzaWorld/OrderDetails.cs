using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaWorld
{
    public class OrderDetails
    {
        public int orderNr;
        public int qty;
        public int price;
        public double totalSum;
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
