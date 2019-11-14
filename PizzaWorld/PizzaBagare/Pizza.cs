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
    }
}
