using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBagare
{
    class Order
    {
        public Order(int orderNumber, List<Pizza> pizzas, List<Extra> extras, OrderStatus status = OrderStatus.New)
        {
            OrderNumber = orderNumber;
            Pizzas = pizzas;
            Extras = extras;
            Status = status;
        }

        public int OrderNumber { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public List<Extra> Extras { get; set; }
        public OrderStatus Status { get; set; }
    }
}
