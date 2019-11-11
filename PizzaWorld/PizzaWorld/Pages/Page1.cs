using System;
using System.Collections.Generic;
using System.Text;
using EasyConsole;

namespace PizzaWorld.Pages
{
    class Page1 : Page
    {
        public Page1(EasyConsole.Program program)
            : base("Page 1", program)
        {


        }
        public override void Display()
        {
            base.Display();


            Object input = Input.ReadInt("Please enter an integer (between 1 and 10):", min: 1, max: 10);
            Output.WriteLine("You wrote: {0}", input);

        }
    }
}
