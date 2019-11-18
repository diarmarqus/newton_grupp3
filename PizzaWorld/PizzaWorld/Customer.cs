using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaWorld
{
   public class Customer
    {
        public int customerID { get; set; }

        public Customer()
        {

        }

        public int CreateCustomerID()
        {
            Random r = new Random();
            int customerID = r.Next(1, 100);
            return customerID;
        }

    }
}
