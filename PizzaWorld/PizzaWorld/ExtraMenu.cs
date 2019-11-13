using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaWorld
{
    class ExtraMenu
    {
        public List<string> drinks= new List<string>() {"Coca cola", "Mineral water", "Fanta", "Sprite", "Cola zero"};
        public List<string> sallad= new List<string>() {"Pizza sallad", "Oliver", "Fefferoni"};
        public List<string> sauce= new List<string>() {"Mayo", "Bearnaise", "Garlic mayo"};
        public int drinksPrice = 30;
        public int SalladPrice = 20;
        public int saucePrice = 20;

        public ExtraMenu()
        {

        }
    }
}
