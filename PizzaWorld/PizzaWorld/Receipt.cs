using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaWorld
{
    public class Receipt
    {
        public int ReceiptNr { get; set; }
        public DateTime date;
        public MenuItems menuItems;
        public OrderDetails orderDetails1;

        public Receipt()
        {
            date = DateTime.Now;
        }

        public int CreateReceiprNr()
        {
            Random r1 = new Random();
            int ReceiptNr = r1.Next(1, 100);
            return ReceiptNr;
        }

        public void ShowReceipt()
        {
            double sumWithoutTax = orderDetails1.totalSum;
            double taxSum = orderDetails1.totalSum * menuItems.moms;
            double tax = menuItems.moms * 100;
            double totalSumWithTax = orderDetails1.totalSum * 1.12;

            Console.WriteLine($"RECEIPT: {ReceiptNr}                    Pizza Palatset            " + date);
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("-------------------------------------------------------------");

            while (ShoppingCart.orderDetails.Count >0)
            {
            for (int i = 0; i < ShoppingCart.orderDetails.Count; i++)
            {
            Console.WriteLine($"{ShoppingCart.orderDetails[i].orderItem.name}                     {ShoppingCart.orderDetails[i].price}"); //vi måste koppla till priset också
            }
            }
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine($"Total sum                      {sumWithoutTax}");
            Console.WriteLine($"TAX {tax}%                     {taxSum}");
            Console.WriteLine($"Total sum with Tax             {totalSumWithTax}");
        }

        public void OutCheckMessage()
        {
            Console.WriteLine("Thank you for your purchase and welcome back!");
        }
    }
}
