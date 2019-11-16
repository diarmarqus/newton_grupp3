﻿/* Copyright Maximilian Cornett 2019-11-16
 * Written in a few hours after several reqeusts for whole different purposes.
 * There is still a bug in the beeping sound which someone in the team might seem fit to fix.
 * Otherwise I think this is what people asked for since I changed my code about 5 times before arriving here.
 * And PS: Sure, the code might seem very C:like but why use objects when they are not needed, That, in my opinion
 * just eats computer resources and we could check that by just adding a timer at the beginning and end of every code
 * in this project, and I'll guarantee that this one would win. Object oriented programming is amazing but shouldn't be
 * used where it is not needed. That just eats up your computers ram and cpu power.
 */
 
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
                pizzaList.Add(new sPizza("Capricciosa", extra, currentpizza));
            else if (randomevent == 1) 
                pizzaList.Add(new sPizza("Tropicana", extra, currentpizza));
            else if (randomevent == 2) 
                pizzaList.Add(new sPizza("Orientale", extra, currentpizza));
            else if (randomevent == 3) 
                pizzaList.Add(new sPizza("Pepperoni", extra, currentpizza));
            else if (randomevent == 4)
                pizzaList.Add(new sPizza("Hamburger", extra, currentpizza));
            else if (randomevent == 5)
                pizzaList.Add(new sPizza("Kebab", extra, currentpizza));
            else if (randomevent == 6)
                pizzaList.Add(new sPizza("4-Cheese", extra, currentpizza));
            else if (randomevent == 7)
                pizzaList.Add(new sPizza("Petersspec", extra, currentpizza));
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
            Console.WriteLine("Here are all the current orders. Order states: (0:Just in, 1: In oven, 2: Finished and ready for pickup)");
            Console.WriteLine("Orders just in:");
            foreach (sPizza pizza in pizzaList)
            {
                if (pizza.state == 0)
                    Console.WriteLine(pizza.ordernumber + ": " + pizza.name + " \twith extra toppings:" + pizza.extra + "\t\t\t state: Order just in");
                //currentPizza++;
            }
            Console.WriteLine("\nOrders in the oven:");
            foreach (sPizza pizza in pizzaList)
            {
                if (pizza.state == 1)
                    Console.WriteLine(pizza.ordernumber + ": " + pizza.name + " \twith extra toppings:" + pizza.extra + "\t\t\t state: In the oven");
            }
            Console.WriteLine("\nOrders ready for pickup:");
            foreach (sPizza pizza in pizzaList)
            {
                if (pizza.state == 2)
                    Console.WriteLine(pizza.ordernumber + ": " + pizza.name + " \twith extra toppings:" + pizza.extra + "\t\t\t state: Ready for pickup");
                //currentPizza++;
            }
        }
        public void MainLoop()
        {
			string key = "Max is the king";

            pizzaList.Add(new sPizza("Capricciosa" , "cheese", 0));
            pizzaList.Add(new sPizza("Tropicana", "cheese", 1));
            pizzaList.Add(new sPizza("Orientale", "cheese", 2));
            pizzaList.Add(new sPizza("Pepperoni", "cheese", 3));

            
            int currentPizza = 4;
            while (true){
                SimulateNext();
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
                    //pizzaList.RemoveAt(number- deletedpizzas);
                    for (int i = pizzaList.Count - 1; i > -1; i--)
                    {
                        if (pizzaList[i].ordernumber == number)
                        {
                            pizzaList.RemoveAt(i);
                        }
                    }
                    deletedpizzas++;
                }
                else if (key == "3")
                {
                    Console.WriteLine("Move pizza to next state with order number:");
                    string pizzanumber = Console.ReadLine();
                    int number = Int32.Parse(pizzanumber); //int number = int.TryParse(pizzanumber);

   
                        for (int i = pizzaList.Count - 1; i > -1; i--)
                        {
                            if (pizzaList[i].ordernumber == number)
                            {
                                if (pizzaList[i].state < 2)
                                    pizzaList[i].MoveToNextState();
                                
                                else
                                    pizzaList.RemoveAt(i);
                            }
                        }

                }


            }


        }

    }
}
