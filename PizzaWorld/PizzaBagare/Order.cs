using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBagare
{
    class Order
    {
        public Order(int orderNumber, List<Pizza> pizzas, List<Extra> extras, OrderStatus orderStatus = OrderStatus.New)
        {
            OrderNumber = orderNumber;
            Pizzas = pizzas;
            Extras = extras;
            OrderStatus = orderStatus;
        }

        public int OrderNumber { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public List<Extra> Extras { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
