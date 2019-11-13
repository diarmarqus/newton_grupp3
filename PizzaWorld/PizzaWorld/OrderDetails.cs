using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaWorld
{
    class OrderDetails
    {
        private int orderNr;
        private int antal;
        private int pris;
        private int totalSum;
        private MenuItems orderItem;

        
        // lägg till: Menu menu;

        // lägg till menu i constructorn
        public OrderDetails(int orderNr, int antal, ) 
        {
            Random random = new Random();
            this.orderNr = random.Next(1, 100);
            this.antal = antal; 

        }
        public void CountTotalSum()
        {
            totalSum = antal * pris;
        }
    }
}
