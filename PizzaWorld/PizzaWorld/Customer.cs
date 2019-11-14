using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaWorld
{
    enum Languages
    {
        Svenska = 0,
        engelska = 1
    }
    class Customer
    {
        public Languages chosenLanguage { get; set; }
        public int customerID { get; set; }

        public Customer(Languages chosenLanguage)
        {
            customerID = 1234;      // lägg till en random nr senare
            this.chosenLanguage = chosenLanguage;
        }

        public void ChoseLanguage(Languages chosenLanguage)
        {
            this.chosenLanguage = chosenLanguage;
        }
    }
}
