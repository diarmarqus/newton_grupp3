using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaBagare
{
    /// <summary>
    /// Hanterar logiken för programmet
    /// </summary>
    class Terminal
    {
        private List<Order> Orders { get; set; }
        private Chef Chef { get; set; }

        private Timer _timer;
        private SoundPlayer _player = new SoundPlayer(@"C:\Windows\media\Alarm01.wav");
        private bool _isPlaying = false;

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
            FlushInputCache();

            int index = 0;

            while ((index < 1 || index > Orders.Count) && index < 10)
            {
                Task.Delay(250).Wait();
                char input = Console.ReadKey(true).KeyChar;

                if (input == 'l')
                {
                    Chef = null;
                    _player.Stop();
                    _isPlaying = false;
                    return;
                }

                int.TryParse(input.ToString(), out index);
            }

            // Ta bort efter sidbyte
            _timer.Dispose();
            _player.Stop();
            _isPlaying = false;


            // Hämtar vald order från Orders via index
            Order order = GetOrderDetails(index);

            DisplayOrderDetails(display, order);
        }

        private void DisplayOrderDetails(Display display, Order order)
        {
            char input;

            while (true)
            {
                display.PrintOrderDetails(order);
                display.PrintBottomInfo(true);
                FlushInputCache();

                Task.Delay(250).Wait();
                input = Console.ReadKey(true).KeyChar;

                if (input != '2' || order.Status == OrderStatus.Done)
                {
                    break;
                }

                Console.WriteLine("Är ordern klar? J/N");

                if (Console.ReadKey(true).KeyChar == 'j')
                {
                    break;
                }

                Console.WriteLine("Avbryter...");
                Task.Delay(250).Wait();
            }

            UpdateOrder(input, order, display);
        }

        private void SetOrders(Data data) => this.Orders = data.Orders;

        // Uppdaterar ordersidan var 5e sekund (TimeSpan.FromSeconds(5))
        private void DisplayOrders(Data data, Display display) =>
            _timer = new Timer((e) =>
            {
                SetOrders(data);
                display.PrintTopInfo("Inloggad: " + Chef.Name);
                display.PrintOrders(Orders);
                display.PrintBottomInfo(false);
                PizzaAlarm();
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

        private void UpdateOrder(char input, Order order, Display display)
        {
            switch (input)
            {
                case '1':
                    order.Status = OrderStatus.InOven;
                    OrderInOven(order);
                    break;
                case '2':
                    order.Status = OrderStatus.Complete;
                    OrderComplete(order, display);
                    break;
                default:
                    break;
            }
        }

        // Uppdatera orderstatus när pizzan är klar
        private void OrderInOven(Order order) =>
            Task.Delay(TimeSpan.FromSeconds(15))
            .ContinueWith(_ => order.Status = OrderStatus.Done);

        private void OrderComplete(Order order, Display display)
        {
            // Skriver ut ordernummret under 2 sek
            display.PrintOrderNumber(order);
            Thread.Sleep(2000);

            // Ta bort ordern efter delay
            Task.Delay(TimeSpan.FromSeconds(5))
                .ContinueWith(_ => Orders.Remove(order));
        }

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

        // Hämta all info om vald order via index
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

        // Starta larm om order är klar att ta ut
        private void PizzaAlarm()
        {
            foreach (var order in Orders)
            {
                if (order.Status == OrderStatus.Done && !_isPlaying)
                {
                    Task.Delay(TimeSpan.FromSeconds(1)).ContinueWith(_ => _player.PlayLooping());
                    _isPlaying = true;
                }
            }
        }

        // Rensa cachade knapptryck
        private void FlushInputCache()
        {
            while (Console.KeyAvailable)
            {
                _ = Console.ReadKey(true);
            }
        }
    }
}
