using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PizzaWorld
{
    /// <summary>
    /// Class to create and store the pizzas menu
    /// </summary>
    public class Menu
    {
        public static int numberOfPizzas = 0;
        public static List<Pizza> standardPizza = new List<Pizza>();
        public static List<string> ingredients = new List<string>() {"Tomato Sauce","Cheese","Ham","Basil","Pineapple", "Mussels",
 "Scampi", "Octopus", "Garlic", "Capers", "Mozzarella", "Gorgonzola", "Parmesan", "Mushrooms", "Kebab", "Ruccola"};
        public static List<List<int>> pizzaNr = new List<List<int>>(); 
        public static List<string> drinks = new List<string>() { "Cola cola", "Fanta", "Water", "Sprite" };
        public static List<string> sallad = new List<string>() { "Pizza salad", "Olives", "Fefferoni" };
        public static List<string> sauce = new List<string>() { "Mayo", "Bearnaise", "Garlic mayo" };

        static List<Pizza> customerPizza = new List<Pizza>();
        public static ExtraMenu extraMenu;
 
        /// <summary>
        /// Creates the standard pizza menu
        /// 
        /// </summary>
        public Menu()
        {
            AddItem(PizzaBase.Italian, new List<int>() { }, "Own choice");
            AddItem(PizzaBase.Italian, new List<int>() {0, 1, 3 }, "Margarita");
            AddItem(PizzaBase.Italian, new List<int>() { 0, 1, 5, 7, 6, 8 }, "Frutti di mare");
            AddItem(PizzaBase.Italian, new List<int>() { 0, 1, 2, 15 }, "Pizza di Parma");
            AddItem(PizzaBase.Italian, new List<int>() { 0, 1, 9 }, "Napoli");
            AddItem(PizzaBase.Italian, new List<int>() { 10, 11, 12 }, "Pizza 3 formaggi");
            AddItem(PizzaBase.Italian, new List<int>() { 0, 1, 3, 4 }, "Group 3 special");
            AddItem(PizzaBase.Italian, new List<int>() { 0, 1, 13, 2, 14 }, "Pizza Rosso");
            AddItem(PizzaBase.Italian, new List<int>() { 0, 1, 15, 8, 6 }, "Newton");
        }

        /// <summary>
        /// Adds a standard pizza to the menu
        /// </summary>
        /// <param name="pBase">The base of the pizza</param>
        /// <param name="ingredientsNr">Array of the positions of the ingredients in the ingredients list</param>
        /// <param name="name">Pizza name</param>
        public void AddItem(PizzaBase pBase, List<int> ingredientsNr, string name)
        {
            numberOfPizzas++;
            pizzaNr.Add(ingredientsNr);
            List<string> ingr = new List<string>();
            for (int i = 0; i < ingredientsNr.Count; i++)
            {
                ingr.Add(ingredients[ingredientsNr[i]]);
            }
            standardPizza.Add(new Pizza(pBase, ingr, name, standardPizza.Count));
        }


        public void AddCustomerPizza(Pizza pizza)
        {
            customerPizza.Add(pizza);
        }

        /// <summary>
        /// just prints out standard pizzas
        /// </summary>
        /// <param name="a">starting</param>
        /// <param name="b">ending</param>
        public static void DisplayPizzas(int a, int b)
        {
            if (b >= standardPizza.Count) b = standardPizza.Count-1;
            if (a < 0 || a > b || a > standardPizza.Count) a = 0;
            for (int i = a; i <= b; i++)
            {
                var sP = standardPizza[i];
                Console.WriteLine(i + ". " + sP.name);
                Console.Write("\t");
                for (int j = 0; j < sP.items.Count; j++)
                {
                    Console.Write(sP.items[j] + ", ");
                }
                Console.WriteLine();
            }
        }
    }
}
