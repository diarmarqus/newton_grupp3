using System;
using System.Collections.Generic;
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
        public Terminal(Data data)
        {
            this.Orders = data.Orders;
        }

        private List<Order> Orders { get; set; }
        private Chef Chef { get; set; }

        private Timer _timer;
        private SoundPlayer _player = new SoundPlayer(@"C:\Windows\media\Alarm01.wav");
        private bool _isPlaying = false;

        // Kör programmet
        public void Run(Data data, Display display)
        {
            Login(data, display);

            DisplayOrders(display);
            FlushInputCache();

            int index = 0;

            while ((index < 1 || index > Orders.Count) && index < 10)
            {
                Task.Delay(250).Wait();
                char input = Console.ReadKey(true).KeyChar;

                if (input == 'l')
                {
                    Chef = null;
                    StopActiveEvents();
                    return;
                }

                int.TryParse(input.ToString(), out index);
            }

            StopActiveEvents();

            // Hämtar vald order från Orders via index
            DisplayOrderDetails(display, GetOrder(index));
        }

        private void Login(Data data, Display display)
        {
            if (_timer != null)
            {
                _timer.Dispose();
            }

            if (Chef != null)
            {
                return;
            }

            FlushInputCache();

            display.PrintTopInfo("Logga in");

            // Loopar loginskärm tills korrekt pin är angedd
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
                Chef = data.GetChef(pin);

                if (Chef == null)
                {
                    display.PrintTopInfo("Fel kod");
                }
            }
        }

        // Uppdaterar ordersidan var 5e sekund (TimeSpan.FromSeconds(5))
        private void DisplayOrders(Display display) =>
            _timer = new Timer((e) =>
            {
                display.PrintTopInfo("Inloggad: " + Chef.Name);
                display.PrintOrders(Orders);
                display.PrintBottomInfo(false);
                PizzaAlarm();
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(2));

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

                var key = Console.ReadKey(true).KeyChar;

                if (key == 'j' || key == '1')
                {
                    break;
                }

                Console.WriteLine("Avbryter...");
                Task.Delay(250).Wait();
            }

            UpdateOrder(input, order, display);
        }

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
            Task.Delay(TimeSpan.FromSeconds(12))
            .ContinueWith(_ => order.Status = OrderStatus.Done);

        private void OrderComplete(Order order, Display display)
        {
            // Skriver ut ordernummret under 2 sek
            display.PrintOrderNumber(order);
            Thread.Sleep(1500);

            // Ta bort ordern efter delay
            Task.Delay(TimeSpan.FromSeconds(2))
                .ContinueWith(_ => Orders.Remove(order));
        }

        // Hämta vald order via index
        private Order GetOrder(int index)
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
                    _player.PlayLooping();
                    _isPlaying = true;
                }
            }
        }

        private void StopActiveEvents()
        {
            _timer.Dispose();
            _player.Stop();
            _isPlaying = false;
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
