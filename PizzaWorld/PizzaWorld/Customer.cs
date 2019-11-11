using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaWorld
{
    enum Lang
    {
        Svenska = 0,
        engelska = 1
    }
    class Customer
    {
        public Lang chosenLang { get; set; }
        public int customerID { get; set; }

        public Customer(Lang chosenLang)
        {
            customerID = 1234;      // lägg till en random nr senare
            this.chosenLang = chosenLang;
        }

        public void ChoseLanguage(Lang chosenLang)
        {
            this.chosenLang = chosenLang;
        }
    }
}
