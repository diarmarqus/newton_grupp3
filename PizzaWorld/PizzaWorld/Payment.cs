using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaWorld
{
    public class Payment
    {
        public double Sum;
        public int orderNumber;
        OrderDetails details;

        public Payment()
        {
            this.orderNumber = details.orderNr;
            this.Sum = details.totalSum;
        }

        public int AddPinCode()
        {
            int userInput = Convert.ToInt32(Console.ReadLine());
            return userInput;
        }

        public bool PaymentAccepted()
        {
            return true;
        }

    }
}
