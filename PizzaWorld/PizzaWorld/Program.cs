using System;

namespace PizzaWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            new MenuCode().Run();

            Menu menu = new Menu();

            Menu.ShowMenu("Menu.txt"); //testa att det funkar
        }
    }
}
