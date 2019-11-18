using System;
using System.Collections.Generic;
using System.Text;
using EasyConsoleCore;

namespace PizzaWorld.Pages
{
    class OrderListMenu : Page
    {
        EasyConsoleCore.Program program;
        public OrderListMenu(EasyConsoleCore.Program program)
                : base("Order list", program)
        {
            this.program = program;
        }
        public override void Display()
        {
            double totalPrice = 0;
            ConsoleKey input;
            int totalQty = 0;
            //Menu visar bara pizzor. Om jag väljer någonting annat, det syns inte här.




            while (true)
            {
                base.Display();
                Console.WriteLine("Order number: " + ShoppingCart.orderDetails[0].orderNr);
                totalPrice = 0;
                for (int i = 0; i < ShoppingCart.orderDetails.Count; i++)
                {
                    Console.WriteLine(i + ". " + "Item: " + ShoppingCart.orderDetails[i].orderItem.name + " " + "Qty: "+ ShoppingCart.orderDetails[i].qty + " " + "Price: " + ShoppingCart.orderDetails[i].price + ":-");
                    totalPrice = totalPrice + ShoppingCart.orderDetails[i].price;
                }
                Console.WriteLine("\n");
                Console.WriteLine($"Number of items: " + ShoppingCart.CountQty() + " " + " " + " " + " " + "Total price: " + ShoppingCart.CountTotalSum() + ":-");
                Console.WriteLine("-----------------------------------------------------------" +
                    "-");



                Console.WriteLine("\n");
                Console.WriteLine("Please press 'P' to pay");
                Console.WriteLine("Please press 'B' to go back to meny to add items");
                Console.WriteLine("Please press 'D' to delete items");
                Console.WriteLine("Please press 'Q' to change quantity of items");
                Console.WriteLine("\n");

                input = Console.ReadKey(true).Key;     

                if (input == ConsoleKey.P)
                {
                    program.NavigateTo<PayMenu>();
                }

                else if (input == ConsoleKey.B)
                {
                    program.NavigateTo<MainMenu>();
                }

                //raderar bara pizzor
                else if (input == ConsoleKey.D)
                {
                    Console.WriteLine("Enter number of the orderline to delete it:");
                    int input2 = Convert.ToInt32(Console.ReadLine());
                    ShoppingCart.DeleteOrder(input2);

                }

                else if (input == ConsoleKey.Q)
                {
                    Console.WriteLine("Enter number of the orderline to change quantity to it and then press Enter:");
                    int input3 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter a number for quantity");
                    int input4 = Convert.ToInt32(Console.ReadLine());
                    ShoppingCart.ChangeQty(input3, input4);
                }
                Console.Clear();

            }
        }
    }
}
