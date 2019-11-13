using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PizzaWorld
{
    class Menu
    {
        public List<Pizza> standardPizza = new List<Pizza>();
        public static List<string> ingredients = new List<string>() {"Tomatsås", "Ost", "Skinka","Basilika", "Ananas", "Blåmusslor",
        "Scampi", "Bläckfisk", "Vitlök", "Kapris", "Mozzarella", "Gorgonzola", "Parmesan", "Champinjoner", "Kebab", "Ruccola"};
        public List<string> drinks = new List<string>() { "Cola cola", "Fanta", "Water", "Sprite" };
        public List<string> sallad = new List<string>() { "Pizza sallad", "Oliver", "Fefferoni" };
        public List<string> sauce = new List<string>() { "Mayo", "Bearnaise", "Garlic mayo" };

        List<Pizza> customerPizza = new List<Pizza>();
       public  ExtraMenu extraMenu;
 

        public Menu()
        {
            AddItem(PizzaBase.Italian, new List<string>() {ingredients[0], ingredients[1], ingredients[3] }, "Margarita");
            AddItem(PizzaBase.Italian, new List<string>() { ingredients[0], ingredients[1], ingredients[5], ingredients[7], ingredients[6], ingredients[8] }, "Frutti di mare");
            AddItem(PizzaBase.Italian, new List<string>() { ingredients[0], ingredients[1], ingredients[2], ingredients[15] }, "Pizza di Parma");
            AddItem(PizzaBase.Italian, new List<string>() { ingredients[0], ingredients[1], ingredients[9] }, "Napoli");
            AddItem(PizzaBase.Italian, new List<string>() { ingredients[10], ingredients[11], ingredients[12] }, "Pizza 3 formaggi");
            AddItem(PizzaBase.Italian, new List<string>() { ingredients[0], ingredients[1], ingredients[3], ingredients[4] }, "Grupp3 special");
            AddItem(PizzaBase.Italian, new List<string>() { ingredients[0], ingredients[1], ingredients[13], ingredients[2], ingredients[14] }, "Pizza Rosso");
            AddItem(PizzaBase.Italian, new List<string>() { ingredients[0], ingredients[1], ingredients[15], ingredients[8], ingredients[6] }, "Newton");

        }
        public void AddItem(PizzaBase pBase, List<string> ingredients, string name)
        {
            standardPizza.Add(new Pizza(pBase, ingredients, name));
        }

        public void AddCustomerPizza(Pizza pizza)
        {
            customerPizza.Add(pizza);
        }

    }
}
