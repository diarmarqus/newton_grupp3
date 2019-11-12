using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace PizzaBagare
{
    /// <summary>
    /// Genera data för Orders/Chefs
    /// </summary>
    class Data
    {
        private List<Order> _dataOrders = new List<Order>();

        public List<Order> Orders = new List<Order>();
        public List<Chef> Chefs = new List<Chef>();

        private Random _rnd = new Random();
        private int _counter = 0;
 
        public Data()
        {
            AddData();
            Timer timer = new Timer(1000 * 6);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_counter >= _dataOrders.Count)
            {
                _counter = 0;
            }

            try
            {
                Order order = _dataOrders[_counter];

                Orders.Add(new Order(_rnd.Next(1000, 4999), order.Pizzas, order.Extras));
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

        public void AddData()
        {
            _dataOrders.Add(new Order(
                4404,
                new List<Pizza>() {
                    new Pizza("Vesuvio"),
                    new Pizza("Kebab")
                },
                new List<Extra>() {
                    new Extra("Cola", "Medium"),
                    new Extra("Sallad")
                }));

            _dataOrders.Add(new Order(
                1110,
                new List<Pizza>() {
                    new Pizza("Egen", new List<string> { "Ost", "Skinka", "Tomater" }, "Standard", "Inbakad"),
                    new Pizza("Kebab")
                },
                new List<Extra>() {
                    new Extra("Pepsi", "Stor"),
                    new Extra("Cola", "Stor"),
                    new Extra("Sallad")
                }));

            _dataOrders.Add(new Order(
                2022,
                new List<Pizza>() {
                    new Pizza("Vesuvio"),
                    new Pizza("Kebab")
                },
                new List<Extra>() {
                    new Extra("Cola", "Medium"),
                    new Extra("Sallad")
                }));

            _dataOrders.Add(new Order(
                4404,
                new List<Pizza>() {
                    new Pizza("Vesuvio"),
                    new Pizza("Kebab")
                },
                new List<Extra>() {
                    new Extra("Cola", "Medium"),
                    new Extra("Sallad")
                }));

            _dataOrders.Add(new Order(
                1110,
                new List<Pizza>() {
                    new Pizza("Egen", new List<string> { "Ost", "Skinka", "Tomater" }, "Standard", "Inbakad"),
                    new Pizza("Kebab")
                },
                new List<Extra>() {
                    new Extra("Pepsi", "Stor"),
                    new Extra("Cola", "Stor"),
                    new Extra("Sallad")
                }));

            _dataOrders.Add(new Order(
                2022,
                new List<Pizza>() {
                    new Pizza("Vesuvio"),
                    new Pizza("Kebab")
                },
                new List<Extra>() {
                    new Extra("Cola", "Medium"),
                    new Extra("Sallad")
                }));

            Chefs.Add(new Chef(1111, "Pizzabagare 1"));
            Chefs.Add(new Chef(2222, "Pizzabagare 2"));
            Chefs.Add(new Chef(3333, "Pizzabagare 3"));
        }
    }
}
