using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaWorld
{
    enum PizzaBase
    {
        Italian = 0,
        American = 1
    }
    enum Ingredients
    {
        Ham = 0,
        Salami = 1,
        Pineapple = 2,
        Banana = 3,
        Mushrooms = 4,
        Onion = 5,
        Tuna = 6,
        Olives = 7,
        Kebab = 8
    }
    class Pizza
    {
        private PizzaBase pBase;
        private List<Ingredients> pIngredients;
        
        public Pizza(PizzaBase pBase, List<Ingredients> pIngredients)
        {
            this.pBase = pBase;
            this.pIngredients = pIngredients;
        }
        
        public void toString()
        {
            // skriv ut pizza
           
        }
    }
}
