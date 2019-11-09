using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaBagare
{
    /// <summary>
    /// Hanterar logiken för programmet
    /// </summary>
    class Terminal
    {
        public List<Order> Orders { get; private set; }
        public Chef Chef { get; private set; }

        // Kör terminalen
        public void Start(Data data, Display display)
        {
            if (Chef == null)
            {
                Login(data, display);
            }

            display.PrintTopInfo("Inloggad: " + Chef.Name);
            display.PrintOrders(Orders);
            display.PrintBottomInfo();

            int index = 0;
            char input;

            while (index < 1 || index > Orders.Count)
            {
                input = GetInput(data, display);

                int.TryParse(input.ToString(), out index);
            }

            Console.Clear();
            Order order = GetOrderDetails(index);

            display.PrintOrderDetails(order);
            display.PrintBottomInfo("Details");

            input = GetInput(data, display);

            UpdateOrder(input, order);
        }

        private static void UpdateOrder(char input, Order order)
        {
            switch (input)
            {
                case '1':
                    order.Status = OrderStatus.InOven;
                    break;
                case '2':
                    order.Status = OrderStatus.Done;
                    break;
                case '3':
                    break;
                default:
                    break;
            }
        }

        private char GetInput(Data data, Display display)
        {
            char input = Console.ReadKey(true).KeyChar;

            if (input == 'l')
            {
                Chef = null;
                Start(data, display);
            }

            return input;
        }

        // Inloggning för bagare
        public void Login(Data data, Display display)
        {
            display.PrintTopInfo();

            VerifyPin(data, display);

            this.Orders = data.Orders;
        }

        // Loop tills korrekt pin är angedd 
        private void VerifyPin(Data data, Display display)
        {
            while (Chef == null)
            {
                Console.Write("Pin: ");

                // Verfiera att userinput är en siffra
                if (!int.TryParse(Console.ReadLine(), out int pin))
                {
                    display.PrintTopInfo("Endast siffror");
                    continue;
                }

                // Verifiera om det finns en bagare med den angivna pinkoden
                Chef = data.Chefs.FirstOrDefault(c => c.Pin == pin);

                if (Chef == null)
                {
                    display.PrintTopInfo("Fel kod");
                }
            }
        }

        // Hämta all info om vald produkt via index
        public Order GetOrderDetails(int index)
        {
            try
            {
                return Orders[index - 1];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }


    }
}
