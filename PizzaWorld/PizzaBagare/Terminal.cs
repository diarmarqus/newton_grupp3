using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaBagare
{
    class Terminal
    {
        public List<Order> Orders { get; private set; }
        public Chef Chef { get; private set; }

        public void LogIn(Data data, Display display)
        {
            Chef chef = null;
            display.PrintLogInInfo();
            while (chef == null)
            {
                Console.Write("Pin: ");
                bool isNum = int.TryParse(Console.ReadLine(), out int pin);

                if (!isNum)
                {
                    display.PrintLogInInfo("Endast siffror");
                    continue;
                }

                chef = data.Chefs.FirstOrDefault(c => c.Pin == pin);

                if (chef == null)
                {
                    display.PrintLogInInfo("Fel kod");
                }
            }

            SetData(data, chef);
        }

        private void SetData(Data data, Chef chef)
        {
            this.Chef = chef;
            this.Orders = data.Orders;
        }

        //private Chef VerifyPin(Data data, int pin) => data.Chefs.FirstOrDefault(c => c.Pin == pin);

        public void GetOrders(Display display) => display.PrintOrders(Orders);
        public void GetOrderDetails(Display display, int index)
        {
            try
            {
                display.PrintOrderDetails(Orders[index - 1]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
