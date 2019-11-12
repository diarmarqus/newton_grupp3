using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace PizzaBagare
{
    /// <summary>
    /// Hanterar logiken för programmet
    /// </summary>
    class Terminal
    {
        private List<Order> Orders { get; set; }
        private Chef Chef { get; set; }

        private System.Threading.Timer _timer;

        // Kör programmet
        public void Start(Data data, Display display)
        {
            if (_timer != null)
            {
                _timer.Dispose();
            }

            // Visa loginskärmen om ingen är inloggad
            if (Chef == null)
            {
                Login(data, display);
            }

            Run(data, display);
        }

        private void Run(Data data, Display display)
        {
            DisplayOrders(data, display);

            int index = 0;

            while (index < 1 || index > Orders.Count)
            {
                char input = Console.ReadKey(true).KeyChar;

                if (input == 'l')
                {
                    Chef = null;
                    return;
                }

                int.TryParse(input.ToString(), out index);
            }

            // Ta bort timer efter sidbyte
            _timer.Dispose();

            // Hämtar vald order från Orders via index
            Order order = GetOrderDetails(index);

            DisplayOrderDetails(order, display);
        }

        private void SetOrders(Data data) => this.Orders = data.Orders;

        private void DisplayOrders(Data data, Display display)
        {
            // Uppdaterar ordersidan var 5e sekund (TimeSpan.FromSeconds(5))
            _timer = new System.Threading.Timer((e) =>
            {
                SetOrders(data);
                display.PrintTopInfo("Inloggad: " + Chef.Name);
                display.PrintOrders(Orders);
                display.PrintBottomInfo();
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
        }

        private void DisplayOrderDetails(Order order, Display display)
        {
            display.PrintOrderDetails(order);
            display.PrintBottomInfo("Details");

            UpdateOrder(Console.ReadKey(true).KeyChar, order, display);
        }

        private void UpdateOrder(char input, Order order, Display display)
        {
            switch (input)
            {
                case '1':
                    order.Status = OrderStatus.InOven;
                    Task.Delay(TimeSpan.FromSeconds(5)).ContinueWith(t => order.Status = OrderStatus.Done);
                    break;
                case '2':
                    order.Status = OrderStatus.Complete;
                    display.PrintOrderNumber(order);
                    Thread.Sleep(3000);
                    // Ta bort ordern efter delay
                    Task.Delay(TimeSpan.FromSeconds(5)).ContinueWith(t => Orders.Remove(order));
                    break;
                default:
                    break;
            }
        }

        //private char GetInput() => Console.ReadKey(true).KeyChar;

        // Inloggning för bagare
        private void Login(Data data, Display display)
        {
            display.PrintTopInfo("Logga in");

            VerifyPin(data, display);

            SetOrders(data);
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
        private Order GetOrderDetails(int index)
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
