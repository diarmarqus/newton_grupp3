using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace PizzaBagare
{
    /// <summary>
    /// Hanterar data för Orders/Chefs
    /// </summary>
    class Data
    {
        public List<Chef> Chefs = new List<Chef>();
        public List<Order> Orders = new List<Order>();

        private List<Order> _dataOrders = new List<Order>();
        private Random _rnd = new Random();
        private int _counter = 0;
 
        public Data()
        {
            // Skapa data för chefs och orders
            AddData();
            // Skicka in nya orders med timer
            TimedOrders();
        }

        public Chef GetChef(int pin) => Chefs.FirstOrDefault(c => c.Pin == pin);

        private void TimedOrders()
        {
            // Starta ny tidsintervall 2.5s
            Timer timer = new Timer(2500);

            // Hämtar OnTimedEvent (ny order) varje intervall
            timer.Elapsed += OnTimedEvent;
            timer.Start();

            // Öka tidsintervall
            Task.Delay(TimeSpan.FromSeconds(10))
                .ContinueWith(_ => timer.Interval = 1000 * 5);
            Task.Delay(TimeSpan.FromSeconds(35))
                .ContinueWith(_ => timer.Interval = 1000 * 15);
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            if (_counter >= _dataOrders.Count)
            {
                _counter = 0;
            }

            try
            {
                AddOrder();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                _counter++;
            }
        }

        private void AddOrder()
        {
            Order order = _dataOrders[_counter];

            Orders.Add(new Order(
                orderNumber: _rnd.Next(1000, 4999),
                pizzas: order.Pizzas,
                extras: order.Extras));
        }

        private void AddData()
        {
            Chefs.Add(new Chef(pin: 111, "Pizzabagare 1"));
            Chefs.Add(new Chef(pin: 222, "Pizzabagare 2"));
            Chefs.Add(new Chef(pin: 333, "Pizzabagare 3"));
            Chefs.Add(new Chef(pin: 123, "Pizzabagare 4"));

            _dataOrders.Add(new Order(
                1,
                new List<Pizza>() {
                    new Pizza("Vesuvio"),
                    new Pizza("Egen", new List<string> { "Ost", "Paprika", "Tomater", "Ruccola", "Fetaost" }, "Stor", PizzaBase.American)
                },
                new List<Extra>() {
                    new Extra("Cola", "Mellan"),
                    new Extra("Sallad")
                }));

            _dataOrders.Add(new Order(
                2,
                new List<Pizza>() {
                    new Pizza("Egen", new List<string> { "Ost", "Skinka", "Tomater" }, "Standard"),
                    new Pizza("Kebab")
                },
                new List<Extra>() {
                    new Extra("Pepsi", "Stor"),
                    new Extra("Cola", "Stor"),
                    new Extra("Sallad")
                }));

            _dataOrders.Add(new Order(
                3,
                new List<Pizza>() {
                    new Pizza("Egen", new List<string> { "Ost", "Paprika", "Tomater", "Ruccola", "Fetaost" }, "Standard"),
                    new Pizza("Egen", new List<string> { "Ost", "Skinka", "Tomater" }, "Standard", PizzaBase.American),
                    new Pizza("Vesuvio")
                },
                new List<Extra>() {
                    new Extra("Cola", "Mellan"),
                    new Extra("Loka", "Stor"),
                    new Extra("Sprite", "Mellan"),
                    new Extra("Sallad")
                }));

            _dataOrders.Add(new Order(
                4,
                new List<Pizza>() {
                    new Pizza("Vesuvio", new List<string> { "Ost", "Tomater" }, "Standard"),
                    new Pizza("Kebab")
                },
                new List<Extra>() {
                    new Extra("Cola", "Mellan"),
                    new Extra("Sprite", "Stor"),
                    new Extra("Sallad")
                }));

            _dataOrders.Add(new Order(
                5,
                new List<Pizza>() {
                    new Pizza("Egen", new List<string> { "Ost", "Skinka", "Tomater" }, "Standard", PizzaBase.American),
                    new Pizza("Kebab")
                },
                new List<Extra>() {
                    new Extra("Pepsi", "Stor"),
                    new Extra("Cola", "Stor"),
                    new Extra("Sallad")
                }));

            _dataOrders.Add(new Order(
                6,
                new List<Pizza>() {
                    new Pizza("Vesuvio"),
                    new Pizza("Kebab")
                },
                new List<Extra>() {
                    new Extra("Cola", "Mellan"),
                    new Extra("Sallad")
                }));
        }
    }
}
