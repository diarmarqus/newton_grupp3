using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace UtlamningsTerminal
{
    public class cTerminal
    {
        int currentpizza = 0, deletedpizzas = 0;
        public class sPizza
        {
            public int state, ordernumber;
            public string name, extra;
			public sPizza(){
				state=0;
				ordernumber=0;
				name= "";
				extra = "";
				
			}
			public sPizza(string pizza, string extras){
				state=0;
				ordernumber=0;
				name= pizza;
				extra = extras;
				
			}
            public sPizza(string pizza, string extras, int ordernumberin)
            {
                state = 0;
                ordernumber = ordernumberin;
                name = pizza;
                extra = extras;

            }
            public void MoveToNextState() {
                state++;

            }
        }
		List<sPizza> pizzaList = new List<sPizza>() ;
        public void MainLoop()
        {
			string key = "Max is the king";

            pizzaList.Add(new sPizza("Capricciosa" , "cheese", 0));
            pizzaList.Add(new sPizza("Tropicana", "cheese", 1));
            pizzaList.Add(new sPizza("Orientale", "cheese", 2));
            pizzaList.Add(new sPizza("Pepperoni", "cheese", 3));

            
            int currentPizza = 4;
            while (true){

                Console.Clear();
                Console.WriteLine("Here are all the current orders. Order states: (0:Just in, 1: In oven, 2: Finished and ready for pickup)");
                foreach (sPizza pizza in pizzaList)
                {
                   // pizza.ordernumber = currentPizza;
                    Console.WriteLine(pizza.ordernumber+ ": " + pizza.name + " \twith extra toppings:" + pizza.extra + "\t\t\t state: "+pizza.state+ "");
                    //currentPizza++;
                }
                Console.WriteLine("What do you want to do? 1. Add Pizza. 2. Delete pizza 3. Move pizza to next state");


                key = Console.ReadLine();

                if (key == "1")
                {
                    Console.WriteLine("Add pizza. What kind?");
                    string pizzatype = Console.ReadLine();
                    Console.WriteLine("Ok you want to add one " + pizzatype + ", any extra toppings with that? (If no type no)");
                    string pizzaextras = Console.ReadLine();

                    pizzaList.Add(new sPizza(pizzatype, pizzaextras, currentPizza));
                    currentPizza++; //go to next ordernumber for the next added pizza
                }
                else if (key == "2")
                {
                    Console.WriteLine("Delete pizza with order number:");
                    string pizzanumber = Console.ReadLine();
                    int number = Int32.Parse(pizzanumber); //int number = int.TryParse(pizzanumber);
                    pizzaList.RemoveAt(number- deletedpizzas);

                    deletedpizzas++;
                }
                else if (key == "3")
                {
                    /* SOMETHING WRONG WITH THIS FUNCTION AS IT THROWS THE WRONG INDEX AND FAILS, NEEDS TO BE FIXED */
                    Console.WriteLine("Move pizza to next state with order number:");
                    string pizzanumber = Console.ReadLine();
                    int number = Int32.Parse(pizzanumber); //int number = int.TryParse(pizzanumber);
                    if (number < pizzaList.Count)
                    {
                        pizzaList[number - deletedpizzas].MoveToNextState();
                        if (pizzaList[number - deletedpizzas].state == 3)
                        {
                            pizzaList.RemoveAt(number);
                            deletedpizzas++;
                        }
                    }
                    else
                    {

                        Console.WriteLine("Error, no pizza with that index");
                        Thread.Sleep(5000);
                    }
                }


            }


        }

    }
}
