using System;
using System.Collections.Generic;
using System.Timers;

namespace UtlamningsTerminal
{
    public class Terminal
    {
        List<Pizza> pizzaList = new List<Pizza>();
        int currentpizza = 8;

        private void SimulateNext()
        {
            Random rnd = new Random();
            int randomevent = rnd.Next(2000, 4000);
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval += randomevent;
            aTimer.Enabled = true;
            Timer aaTimer = new Timer();
            aaTimer.Elapsed += new ElapsedEventHandler(AddRandomPizza);
            aaTimer.Interval += 7000;
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
                pizzaList.Add(new Pizza("Margherita", extra, currentpizza));
            else if (randomevent == 1)
                pizzaList.Add(new Pizza("Frutti di mare", extra, currentpizza));
            else if (randomevent == 2)
                pizzaList.Add(new Pizza("Pizza di Parma", extra, currentpizza));
            else if (randomevent == 3)
                pizzaList.Add(new Pizza("Napoli", extra, currentpizza));
            else if (randomevent == 4)
                pizzaList.Add(new Pizza("Pizza 3 formaggi", extra, currentpizza));
            else if (randomevent == 5)
                pizzaList.Add(new Pizza("Group3 special", extra, currentpizza));
            else if (randomevent == 6)
                pizzaList.Add(new Pizza("Pizza Rosso", extra, currentpizza));
            else if (randomevent == 7)
                pizzaList.Add(new Pizza("Newton", extra, currentpizza));
            currentpizza++;
        }

        // Specify what you want to happen when the Elapsed event is raised.
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Random rnd = new Random();
            int randomevent = rnd.Next(0, pizzaList.Count);

            for (int i = pizzaList.Count - 1; i > -1; i--)
            {
                if (randomevent == i)
                {
                    pizzaList[i].MoveToNextState();
                }
                if (pizzaList[i].state == 2)
                    Console.Beep();
                if (pizzaList[i].state == 3)
                    pizzaList.RemoveAt(i);
            }

            Console.Clear();
            Console.WriteLine("ORDERS JUST IN:");
            foreach (Pizza pizza in pizzaList)
            {
                if (pizza.state == 0)
                    Console.WriteLine($" {pizza.ordernumber,-2}  {pizza.name,-16} with extra toppings: {pizza.extra} ");
            }
            Console.WriteLine("\n");
            Console.WriteLine("\nORDERS IN MAKING:");
            foreach (Pizza pizza in pizzaList)
            {
                if (pizza.state == 1)
                    Console.WriteLine($" {pizza.ordernumber,-2}  {pizza.name,-16} with extra toppings: {pizza.extra} ");
            }

            Console.WriteLine("\n");
            Console.WriteLine("\nORDERS READY FOR PICK UP:");
            foreach (Pizza pizza in pizzaList)
            {
                if (pizza.state == 2)
                    Console.WriteLine($" {pizza.ordernumber,-2}  {pizza.name,-16} with extra toppings: {pizza.extra} ");
            }
        }

        public void MainLoop()
        {
            pizzaList.Add(new Pizza("Margherita", "cheese", 1));
            pizzaList.Add(new Pizza("Frutti di mare", "cheese", 2));
            pizzaList.Add(new Pizza("Pizza di Parma", "cheese", 3));
            pizzaList.Add(new Pizza("Pizza 3 formaggi", "cheese", 4));
            pizzaList.Add(new Pizza("Group3 special", "cheese", 5));
            pizzaList.Add(new Pizza("Pizza Rosso", "cheese", 6));
            pizzaList.Add(new Pizza("Newton", "cheese", 7));

            SimulateNext();
            Console.Clear();

            Console.ReadLine();
        }
    }
}