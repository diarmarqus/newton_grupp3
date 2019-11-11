using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaWorld
{
    class OrderDetails
    {
        private int orderNr;
        private string produktNamn;
        private int antal;
        private int pris;
        private int totalSum;
        private double moms;

        // lägg till: Menu menu;

        // lägg till menu i constructorn
        public OrderDetails(int orderNr, int antal) 
        {
            // orderNr ska vara random generated
            moms = 0.12;
        }
        public void CountTotalSum()
        {
            totalSum = antal * pris;
        }
    }
}
