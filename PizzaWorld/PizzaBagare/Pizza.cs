using System.Collections.Generic;

namespace PizzaBagare
{
    class Pizza
    {
        public Pizza(string name, string size = "Standard")
        {
            this.Name = name;
            this.Size = size;
        }

        public Pizza(string name, List<string> ingredients, string size, PizzaBase crust = PizzaBase.Italian)
        {
            this.Name = name;
            this.Ingredients = ingredients;
            this.Size = size;
            this.PizzaBase = crust;
        }

        public string Name { get; set; }
        public List<string> Ingredients { get; set; }
        public string Size { get; set; }
        public PizzaBase PizzaBase { get; set; }

        public string GetPizza() => $" - {Name} {GetIngredients()}{Size} {PizzaBase.GetDescription()}";

        private string GetIngredients()
        {
            if (Ingredients == null)
            {
                return null;
            }

            string ingredients = "";

            foreach (string ingredient in Ingredients)
            {
                ingredients += ingredient;
                if (Ingredients.IndexOf(ingredient) != Ingredients.Count - 1)
                {
                    ingredients += ", ";
                }
            }

            return $"({ingredients}) ";
        }
    }
}
