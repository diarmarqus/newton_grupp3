using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBagare
{
    class Data
    {
        public List<Order> Orders = new List<Order>();
        public List<Chef> Chefs = new List<Chef>();

        public Data()
        {
            AddData();
        }

        /// <summary>
        /// Genera data för Orders/Chefs
        /// </summary>
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
