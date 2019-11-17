using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Timers;

namespace UtlamningsTerminal
{
    public class cTerminal
    {
        int currentpizza = 4, deletedpizzas = 0;
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
        private void SimulateNext(){
            Random rnd = new Random();
            int randomevent = rnd.Next(2000, 4000);
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = randomevent;
            aTimer.Enabled = true;
            System.Timers.Timer aaTimer = new System.Timers.Timer();
            aaTimer.Elapsed += new ElapsedEventHandler(AddRandomPizza);
            aaTimer.Interval = 7000;
            aaTimer.Enabled = true;
        }
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
        }
            // Specify what you want to happen when the Elapsed event is raised.
            private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Random rnd = new Random();
            int randomevent = rnd.Next(0, pizzaList.Count);
            int count = 0;

            for (int i = pizzaList.Count - 1; i > -1; i--)
            {
                if (randomevent == i)
                {
                    pizzaList[i].MoveToNextState();
                }
                if(pizzaList[i].state == 2)
                    Console.Beep();
                if (pizzaList[i].state == 3)
                    pizzaList.RemoveAt(i);
            }/*
            foreach (sPizza pizza in pizzaList)
            {
                if (count == randomevent)
                {
                    //Random event occurs on this pizza


                }
                count++;
            }*/
            Console.Clear();
            Console.WriteLine("Here are all the current orders.");
            Console.WriteLine("ORDERS JUST IN:");
            foreach (sPizza pizza in pizzaList)
            {
                if (pizza.state == 0)
                    Console.WriteLine(pizza.ordernumber + ": " + pizza.name + " \twith extra toppings:" + pizza.extra);
                //currentPizza++;
            }
            Console.WriteLine("\n");
            Console.WriteLine("\nORDERS IN MAKING:");
            foreach (sPizza pizza in pizzaList)
            {
                if (pizza.state == 1)
                    Console.WriteLine(pizza.ordernumber + ": " + pizza.name + " \twith extra toppings:" + pizza.extra);
            }
            Console.WriteLine("\n");
            Console.WriteLine("\nORDERS READY FOR PICK UP:");
            foreach (sPizza pizza in pizzaList)
            {
                if (pizza.state == 2)
                    Console.WriteLine(pizza.ordernumber + ": " + pizza.name + " \twith extra toppings:" + pizza.extra);
                //currentPizza++;
            }
        }
        public void MainLoop()
        {
			string key = "Max is the king";

            pizzaList.Add(new sPizza("Margherita", "cheese", 0));
            pizzaList.Add(new sPizza("Frutti di mare", "cheese", 1));
            pizzaList.Add(new sPizza("Pizza di Parma", "cheese", 2));
            pizzaList.Add(new sPizza("Pizza 3 formaggi", "cheese", 3));
            pizzaList.Add(new sPizza("Group3 special", "cheese", 4));
            pizzaList.Add(new sPizza("Pizza Rosso", "cheese", 5));
            pizzaList.Add(new sPizza("Newton", "cheese", 6));


            int currentPizza = 4;
            while (true){
                SimulateNext();
                Console.Clear();
                Console.WriteLine("Here are all the current orders.");
                foreach (sPizza pizza in pizzaList)
                {
                   // pizza.ordernumber = currentPizza;
                    Console.WriteLine(pizza.ordernumber+ ": " + pizza.name + " \twith extra toppings:" + pizza.extra);
                    //currentPizza++;
                }
                //Console.WriteLine("What do you want to do? 1. Add Pizza. 2. Delete pizza 3. Move pizza to next state");


                key = Console.ReadLine();

                //if (key == "1")
                //{
                //    Console.WriteLine("Add pizza. What kind?");
                //    string pizzatype = Console.ReadLine();
                //    Console.WriteLine("Ok you want to add one " + pizzatype + ", any extra toppings with that? (If no type no)");
                //    string pizzaextras = Console.ReadLine();

                //    pizzaList.Add(new sPizza(pizzatype, pizzaextras, currentPizza));
                //    currentPizza++; //go to next ordernumber for the next added pizza
                //}
                //else if (key == "2")
                //{
                //    Console.WriteLine("Delete pizza with order number:");
                //    string pizzanumber = Console.ReadLine();
                //    int number = Int32.Parse(pizzanumber); //int number = int.TryParse(pizzanumber);
                //    //pizzaList.RemoveAt(number- deletedpizzas);
                //    for (int i = pizzaList.Count - 1; i > -1; i--)
                //    {
                //        if (pizzaList[i].ordernumber == number)
                //        {
                //            pizzaList.RemoveAt(i);
                //        }
                //    }
                //    deletedpizzas++;
                //}
                //else if (key == "3")
                //{
                //    Console.WriteLine("Move pizza to next state with order number:");
                //    string pizzanumber = Console.ReadLine();
                //    int number = Int32.Parse(pizzanumber); //int number = int.TryParse(pizzanumber);

   
                //        for (int i = pizzaList.Count - 1; i > -1; i--)
                //        {
                //            if (pizzaList[i].ordernumber == number)
                //            {
                //                if (pizzaList[i].state < 2)
                //                    pizzaList[i].MoveToNextState();
                                
                //                else
                //                    pizzaList.RemoveAt(i);
                //            }
                //        }

                //}


            }


        }

    }
}
