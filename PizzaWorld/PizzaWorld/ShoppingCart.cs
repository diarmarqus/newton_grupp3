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
        private static List<OrderDetails> _orderDetails = new List<OrderDetails>();
        private static OrderDetails _workingOrderDetails;

        public static List<OrderDetails> orderDetails { get { return _orderDetails; } set { _orderDetails = value; } }
        public static OrderDetails workingOrderDetails { get { return _workingOrderDetails; } set { _workingOrderDetails = value; } }

        public static void addOrder(OrderDetails aOrderDetails)
        {
            orderDetails.Add(aOrderDetails);
        }

        public static void DeleteOrder(int place)
        {
            orderDetails.RemoveAt(place);
        }
        public static void ChangeQty(int place, int change)
        {
            orderDetails[place].qty = change;

        }
        public static int CountQty()
        {
            int sum = 0;
            foreach (var item in orderDetails)
            {
                sum = sum + item.qty;
            }
            return sum;

        }

        public static int CountTotalSum()
        {
            int sum = 0;
            for (int i = 0; i < orderDetails.Count; i++)
            {
                sum = sum + orderDetails[i].price;
            }
            return sum;
        }
        
  
    }
}
