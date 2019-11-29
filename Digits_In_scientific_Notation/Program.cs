using System;

namespace Digits_In_scientific_Notation
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = 0.123456789;
            double number2 = 10000000000000000;

            Console.WriteLine(number.ToString("0.##########E+0#"));
            Console.WriteLine(number2.ToString("0.0000000000E+00"));

            Console.WriteLine(number.ToString("0.0000000000E+0#"));

            Console.ReadKey();
        }
    }
}
