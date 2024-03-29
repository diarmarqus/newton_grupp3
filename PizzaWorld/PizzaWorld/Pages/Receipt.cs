﻿using System;
using System.Collections.Generic;
using System.Text;
using EasyConsoleCore;
using ConsoleTables;

namespace PizzaWorld.Pages
{
    class Receipt : Page
    {
        EasyConsoleCore.Program program;
        public Receipt(EasyConsoleCore.Program program)
                : base("Receipt", program)
        {
            this.program = program;
        }
        public int CreateReceiprNr()
        {
            Random r1 = new Random();
            int ReceiptNr = r1.Next(1, 100);
            return ReceiptNr;
        }
        int x = 0;
        double totalPrice = 0;

        public override void Display()
        {

            while (true)
            {
                double SumAfterTax = ShoppingCart.CountTotalSum() * 0.12;
                base.Display();
                Console.WriteLine("--------------------------------------------------");
                ConsoleColor.Yellow.WriteLine("RECEIPT #" + CreateReceiprNr() + "                    " + DateTime.Now);
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("Order number: " + ShoppingCart.orderDetails[0].orderNr + "\n");
                var table = new ConsoleTable("No", "Product", "Qty", "Price");
                //totalPrice = 0;
                for (int i = 0; i < ShoppingCart.orderDetails.Count; i++)
                {
                    table.AddRow(i, ShoppingCart.orderDetails[i].orderItem.name, ShoppingCart.orderDetails[i].qty, ShoppingCart.orderDetails[i].price);
                    //Console.WriteLine((i+1) + ". " + ShoppingCart.orderDetails[i].orderItem.name + "          " + "Qty: " + ShoppingCart.orderDetails[i].qty + "          " + "Price: " + ShoppingCart.orderDetails[i].price + ":-");
                    //totalPrice = totalPrice + ShoppingCart.orderDetails[i].price;
                }
                table.Write();
                Console.WriteLine("\n");
                Console.WriteLine($"Items: {ShoppingCart.CountQty()}" + " " + " " + " " + " " + "Total price: " + ShoppingCart.CountTotalSum() + ":-" + " " + " " + " " + "Tax: " + SumAfterTax + ":- " + "(12 %)");
                Console.WriteLine("--------------------------------------------------" +
                    "-");
                Console.WriteLine("Printing out... \n");
                string banner = " _    _      _                            _                _    _\n" +
                    "| |  | |    | |                          | |              | |  | |\n" +
                    "| |  | | ___| | ___ ___  _ __ ___   ___  | |__   __ _  ___| | _| |\n" +
                    "| |/\\| |/ _ \\ |/ __/ _ \\| '_ ` _ \\ / _ \\ | '_ \\ / _` |/ __| |/ / |\n" +
                    "\\  /\\  /  __/ | (_| (_) | | | | | |  __/ | |_) | (_| | (__|   <|_|\n" +
                    " \\/  \\/ \\___|_|\\___\\___/|_| |_| |_|\\___| |_.__/ \\__,_|\\___|_|\\_(_)\n";

                Console.WriteLine(banner);
                Console.ReadKey();
                Console.Clear();
            }

        }
    }
}
