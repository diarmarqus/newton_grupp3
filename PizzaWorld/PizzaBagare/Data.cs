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
        public List<Order> Orders = new List<Order>();
        public List<Chef> Chefs = new List<Chef>();
        Random rnd = new Random();

        public Data()
        {
            Timer timer = new Timer(1000 * 10);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            AddData();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Orders.Add(new Order(
            rnd.Next(1000, 5999),
            new List<Pizza>() {
                new Pizza("Vesuvio"),
                new Pizza("Kebab")
            },
            new List<Extra>() {
                new Extra("Cola", "Medium"),
                new Extra("Sallad")
            }));
        }

        public void AddData()
        {
            Orders.Add(new Order(
                4404,
                new List<Pizza>() {
                    new Pizza("Vesuvio"),
                    new Pizza("Kebab")
                },
                new List<Extra>() {
                    new Extra("Cola", "Medium"),
                    new Extra("Sallad")
                }));

            Orders.Add(new Order(
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

            Orders.Add(new Order(
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
