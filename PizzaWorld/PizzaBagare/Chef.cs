using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBagare
{
    class Chef
    {
        public Chef(int pin, string name)
        {
            this.Pin = pin;
            this.Name = name;
        }

        public int Pin { get; set; }
        public string Name { get; set; }
    }
}
