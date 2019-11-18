using System;
using System.Collections.Generic;
using System.Text;

namespace Utcheckningsterminal
{
    class cTerminal
    {
        public class sPizza
        {
            public int state, ordernumber;
            public string name, extra;
            public sPizza()
            {
                state = 0;
                ordernumber = 0;
                name = "";
                extra = "";

            }
            public sPizza(string pizza, string extras)
            {
                state = 0;
                ordernumber = 0;
                name = pizza;
                extra = extras;

            }
            public sPizza(string pizza, string extras, int ordernumberin)
            {
                state = 0;
                ordernumber = ordernumberin;
                name = pizza;
                extra = extras;

            }
            public void MoveToNextState()
            {
                state++;

            }
        }


        public void start()
        {

            List<sPizza> pizzaList = new List<sPizza>();

            pizzaList.Add(new sPizza("Capricciosa", "Nothing", 0));
            pizzaList.Add(new sPizza("Capricciosa", "cheese", 1));
            pizzaList.Add(new sPizza("Capricciosa", "Mozarella", 2));
            pizzaList.Add(new sPizza("Capricciosa", "Nothing", 3));
            while (true)
            {

                Console.Clear();
                foreach (sPizza pizza in pizzaList)
                {
                    if (pizza.state == 0)
                        Console.WriteLine(pizza.ordernumber + ": " + pizza.name + " \twith extra toppings:" + pizza.extra + "\t\t\t state: Ready for checkout!");
                    //currentPizza++;
                }

                Console.WriteLine("PIZZA CHECKOUT. Check out pizza number:");
                string pizzanumber = Console.ReadLine();

                int number = Int32.Parse(pizzanumber); //int number = int.TryParse(pizzanumber);

                /* Make sure no one tries to delete an empty array */
                for (int i = pizzaList.Count - 1; i > -1; i--)
                {

                    if (pizzaList[i].ordernumber == number)
                    {
                        pizzaList.RemoveAt(i);
                    }
                }

            }
        }
    }
}
