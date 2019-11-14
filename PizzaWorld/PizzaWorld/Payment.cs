using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaWorld
{
    class Payment
    {
        private int Sum;
        private int OrderNr;

        public Payment(int sum)
        {
            this.Sum = sum; //ta summa från ShoppingCart
            this.OrderNr = 11; //sätt random nr.
        }

        public void ShowAmount()
        {

        }

        public void ShowOrderNr()
        {

        }

        public int AddPinCode()
        {
            return 11;
        }

        public bool PaymentAccepted()
        {
            return true;
        }

    }
}
