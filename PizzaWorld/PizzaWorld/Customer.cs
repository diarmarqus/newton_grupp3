using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaWorld
{
    enum Language
    {
        Svenska = 0,
        engelska = 1
    }
    class Customer
    {
        public Language chosenLanguage { get; set; }
        public int customerID { get; set; }

        public Customer(Language chosenLanguage)
        {
            customerID = 1234;      // lägg till en random nr senare
            this.chosenLanguage = chosenLanguage;
        }

        public void ChoseLanguage(Language chosenLanguage)
        {
            this.chosenLanguage = chosenLanguage;
        }
    }
}
