using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaWorld
{
    public static class ExtensionMethods
    {
        public static void WriteLine(this ConsoleColor Color, string Text)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(Text);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void Write(this ConsoleColor Color, string Text)
        {
            Console.ForegroundColor = Color;
            Console.Write(Text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
