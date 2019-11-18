using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ConsoleTables;

namespace PizzaWorld
{
    /// <summary>
    /// Class to create and store the pizzas menu
    /// </summary>
    public class Menu
    {
        private static int _numberOfPizzas = 0;
        private static List<Pizza> _standardPizza = new List<Pizza>();
        private static List<string> _pizzaBase = new List<string>() { "Italian", "American" };
        private static List<string> _ingredients = new List<string>() {"Tomato Sauce","Cheese","Ham","Basil","Pineapple", "Mussels",
 "Scampi", "Octopus", "Garlic", "Capers", "Mozzarella", "Gorgonzola", "Parmesan", "Mushrooms", "Kebab", "Ruccola"};
        private static List<List<int>> _pizzaNr = new List<List<int>>(); 
        private static List<string> _drinks = new List<string>() { "Cola cola", "Fanta", "Water", "Sprite" };
        private static List<string> _sallad = new List<string>() { "Pizza salad", "Olives", "Fefferoni" };
        private static List<string> _sauce = new List<string>() { "Mayo", "Bearnaise", "Garlic mayo" };

        //static List<Pizza> customerPizza = new List<Pizza>();
        private static ExtraMenu _extraMenu;

        public static int numberOfPizzas { get { return _numberOfPizzas; } set { _numberOfPizzas = value; } }
        public static List<Pizza> standardPizza { get { return _standardPizza; } set { _standardPizza = value; } }
        public static List<string> pizzaBase { get { return _pizzaBase; } set { _pizzaBase = value; } }
        public static List<string> ingredients { get { return _ingredients; } set { _ingredients = value; } }
        public static List<List<int>> pizzaNr { get { return _pizzaNr; } set { _pizzaNr = value; } }
        public static List<string> drinks { get { return _drinks; } set { _drinks = value; } }
        public static List<string> sallad { get { return _sallad; } set { _sallad = value; } }
        public static List<string> sauce { get { return _sauce; } set { _sauce = value; } }
        public static ExtraMenu extraMenu { get { return _extraMenu; } set { _extraMenu = value; } }


        /// <summary>
        /// Creates the standard pizza menu
        /// 
        /// </summary>
        public Menu()
        {
            AddItem(pizzaBase[0], new List<int>() { }, "Own choice");
            AddItem(pizzaBase[0], new List<int>() {0, 1, 3 }, "Margarita");
            AddItem(pizzaBase[0], new List<int>() { 0, 1, 5, 7 }, "Frutti di mare");
            AddItem(pizzaBase[0], new List<int>() { 0, 1, 2, 15 }, "Pizza di Parma");
            AddItem(pizzaBase[0], new List<int>() { 0, 1, 9 }, "Napoli");
            AddItem(pizzaBase[0], new List<int>() { 10, 11, 12 }, "Pizza 3 formaggi");
            AddItem(pizzaBase[0], new List<int>() { 0, 1, 3, 4 }, "Group 3 special");
            AddItem(pizzaBase[0], new List<int>() { 0, 1, 13, 2, 14 }, "Pizza Rosso");
            AddItem(pizzaBase[0], new List<int>() { 0, 1, 15, 8, 6 }, "Newton");
        }

        /// <summary>
        /// Adds a standard pizza to the menu
        /// </summary>
        /// <param name="pBase">The base of the pizza</param>
        /// <param name="ingredientsNr">Array of the positions of the ingredients in the ingredients list</param>
        /// <param name="name">Pizza name</param>
        public void AddItem(string pBase, List<int> ingredientsNr, string name)
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


        //public void AddCustomerPizza(Pizza pizza)
        //{
        //    customerPizza.Add(pizza);
        //}

        /// <summary>
        /// just prints out standard pizzas
        /// </summary>
        /// <param name="a">starting</param>
        /// <param name="b">ending</param>
        public static void DisplayPizzas(int a, int b)
        {
            var table = new ConsoleTable("No", "Product");
            string output1 = "";
            string output2 = "";
            if (b >= standardPizza.Count) b = standardPizza.Count-1;
            if (a < 0 || a > b || a > standardPizza.Count) a = 0;
            for (int i = a; i <= b; i++)
            {
                var sP = standardPizza[i];

                output1 = i + ". " + sP.name;
               
                for (int j = 0; j < sP.items.Count; j++)
                {
                    output2 += sP.items[j] + ", ";
                    if ((j+1)%3 == 0)
                    {
                        table.AddRow(output1, output2);
                        output1 = "";
                        output2 = "";
                    }
                }
                if (output1 != "")
                    table.AddRow(output1, output2);
            }
            table.Write();
        }
    }
}
