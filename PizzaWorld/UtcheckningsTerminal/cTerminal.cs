using System;
using System.Collections.Generic;
using System.Text;

using System.Timers;
namespace Utcheckningsterminal
{
    class cTerminal
    {

        List<sPizza> pizzaList = new List<sPizza>();

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
        int currentpizza = 4;
        private void AddRandomPizza(object source, ElapsedEventArgs e)
        {
            Random rnd = new Random();
            int randomevent = rnd.Next(0, 8);
            Random rndextra = new Random();
            int randomextra = rnd.Next(0, 7);
            string extra = "nothing";
            if (randomextra == 0)
                extra = "nothing";
            else if (randomextra == 1)
                extra = "cheese";
            else if (randomextra == 2)
                extra = "pepperoni";
            else if (randomextra == 3)
                extra = "fefferoni";
            else if (randomextra == 4)
                extra = "mozarella";
            else if (randomextra == 5)
                extra = "onions";
            else if (randomextra == 6)
                extra = "mushrooms";

            if (randomevent == 0)
                pizzaList.Add(new sPizza("Margherita", extra, currentpizza));
            else if (randomevent == 1)
                pizzaList.Add(new sPizza("Frutti di mare", extra, currentpizza));
            else if (randomevent == 2)
                pizzaList.Add(new sPizza("Pizza di Parma", extra, currentpizza));
            else if (randomevent == 3)
                pizzaList.Add(new sPizza("Napoli", extra, currentpizza));
            else if (randomevent == 4)
                pizzaList.Add(new sPizza("Pizza 3 formaggi", extra, currentpizza));
            else if (randomevent == 5)
                pizzaList.Add(new sPizza("Group3 special", extra, currentpizza));
            else if (randomevent == 6)
                pizzaList.Add(new sPizza("Pizza Rosso", extra, currentpizza));
            else if (randomevent == 7)
                pizzaList.Add(new sPizza("Newton", extra, currentpizza));
            currentpizza++;


            Console.Clear();
            foreach (sPizza pizza in pizzaList)
            {
                if (pizza.state == 0)
                    Console.WriteLine(pizza.ordernumber + ": " + pizza.name + " \t\twith extra toppings:" + pizza.extra + "\t\t\t state: Ready for checkout!");
                //currentPizza++;
            }

            Console.WriteLine("PIZZA CHECKOUT. Check out pizza number:");
        }
        public void start()
        {

            pizzaList.Add(new sPizza("Capricciosa", "Nothing", 0));
            pizzaList.Add(new sPizza("Capricciosa", "cheese", 1));
            pizzaList.Add(new sPizza("Capricciosa", "Mozarella", 2));
            pizzaList.Add(new sPizza("Capricciosa", "Nothing", 3));
            System.Timers.Timer aaTimer = new System.Timers.Timer();
            aaTimer.Elapsed += new ElapsedEventHandler(AddRandomPizza);
            aaTimer.Interval = 2000;
            aaTimer.Enabled = true;
            while (true)
            {

                Console.Clear();
                foreach (sPizza pizza in pizzaList)
                {
                    if (pizza.state == 0)
                        Console.WriteLine(pizza.ordernumber + ": " + pizza.name + " \t\twith extra toppings:" + pizza.extra + "\t\t\t state: Ready for checkout!");
                    //currentPizza++;
                }

                Console.WriteLine("PIZZA CHECKOUT. Check out pizza number:");
                
                    string pizzanumber = Console.ReadLine();
                    int number = -1;
                    Int32.TryParse(pizzanumber, out number);
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
