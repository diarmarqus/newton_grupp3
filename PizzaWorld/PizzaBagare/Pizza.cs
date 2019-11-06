using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBagare
{
    class Pizza
    {
        public Pizza(string name, string size, string crust)
        {
            this.Name = name;
            this.Size = size;
            this.Crust = crust;
        }

        public Pizza(string name, List<string> ingredients, string size, string crust)
        {
            this.Name = name;
            this.Ingredients = ingredients;
            this.Size = size;
            this.Crust = crust;
        }

        public string Name { get; set; }
        public List<string> Ingredients { get; set; }
        public string Size { get; set; }
        public string Crust { get; set; }
    }
}
