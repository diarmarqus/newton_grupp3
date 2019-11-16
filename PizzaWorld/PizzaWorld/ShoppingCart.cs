using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaWorld
{

    /// <summary>
    /// Class for all the the orders the user has stored
    /// </summary>
    public static class ShoppingCart
    {
        //public static Menu menu = new Menu();


        // Variables that stores all the orders the users has picked
        public static List<OrderDetails> orderDetails = new List<OrderDetails>();
        public static OrderDetails drinksOrderDetails = new OrderDetails(new ExtraMenu(new List<string>(), "Drinks", 20));
        public static OrderDetails salladOrderDetails = new OrderDetails(new ExtraMenu(new List<string>(), "Sallad", 20));
        public static OrderDetails sauceOrderDetails = new OrderDetails(new ExtraMenu(new List<string>(), "Sauce", 20));
        public static OrderDetails workingOrderDetails;
       


       

        public static void addOrder(OrderDetails aOrderDetails)
        {
            orderDetails.Add(aOrderDetails);
        }

        public static void ChangeQty(int place, int change)
        {
            orderDetails[place].qty += change;

        }

        public static int CountTotalSum()
        {
            int sum = 0;
            for (int i = 0; i < orderDetails.Count; i++)
            {
                sum = sum + orderDetails[i].price;
            }
            sum += drinksOrderDetails.orderItem.totalPrice;
            sum += salladOrderDetails.orderItem.totalPrice;
            sum += sauceOrderDetails.orderItem.totalPrice;
            return sum;
        }

  
    }
}
