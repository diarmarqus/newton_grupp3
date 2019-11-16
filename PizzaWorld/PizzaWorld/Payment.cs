using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaWorld
{
    public class Payment
    {

        public Payment()
        {

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
