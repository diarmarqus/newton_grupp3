using System;

namespace exeption
{
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                Console.Write("Din inkomst: ");
                double salary = double.Parse(Console.ReadLine());

                Console.Write("Antal tim: ");
                double time = double.Parse(Console.ReadLine());

                double avarage = salary / time;

                Console.WriteLine(avarage);
            }
            catch (DivideByZeroException)
            {
                Console.Write("Cannot divide by zero. Please try again.");
            }
            catch (InvalidOperationException)
            {
                Console.Write("Not a valid number. Please try again.");
            }
            catch (FormatException)
            {
                Console.Write("Not a valid number. Please try again.");
            }

            Console.ReadKey();

        }
    }
}
