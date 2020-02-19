using System;
using static System.Math;           // a class név nélkül hívhatóak a static függvények innen ezentúl


namespace Investigate_NamedAndOptional
{
    class Program
    {

        public int Property { get; set; } = 30;     // Auto property initialiser




        static void Main(string[] args)
        {
            Console.WriteLine(Sqrt(23));


            Program.DoSomething("Hehe", 10, 20);

            Program.DoSomething("Hehe", 10);

            Console.ReadKey();
        }


        static void DoSomething(string input1, int input2)
        {
            Console.WriteLine($"{nameof(DoSomething)} {input1} {input2}");
        }

        static void DoSomething(string input1, int input2, int input3 = 1000)
        {
            Console.WriteLine($"{nameof(DoSomething)} opcionális {input1} {input2} {input3}");
        }


    }
}
