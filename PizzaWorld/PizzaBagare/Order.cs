using System;
using System.Collections.Generic;

namespace PizzaBagare
{
    class Order
    {
        public Order(int orderNumber, List<Pizza> pizzas, List<Extra> extras)
        {
            OrderNumber = orderNumber;
            Pizzas = pizzas;
            Extras = extras;
            Status = OrderStatus.New;
        }

        public int OrderNumber { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public List<Extra> Extras { get; set; }
        public OrderStatus Status { get; set; }


        public string GetPizzas()
        {
            string pizzas = "";

            foreach (var pizza in Pizzas)
            {
                pizzas += pizza.GetPizza() + Environment.NewLine;
            }

            return pizzas;
        }

        public string GetExtras()
        {
            string extras = "";

            foreach (var extra in Extras)
            {
                extras += extra.GetExtra() + Environment.NewLine;
            }

            return extras;
        }
    }
}
