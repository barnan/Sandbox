using System;

namespace Investigate_CSharp_6And7
{
    class Program
    {
        static ExampleClass[] ec = new ExampleClass[] { new ExampleClass { Property1 = 10 }, new ExampleClass { Property1 = 20 }, new ExampleClass { Property1 = 30 } };
        static int[] el = new int[] { 10, 20, 30 };


        static void Main(string[] args)
        {

            // --------------------------------------- ref return --------------------------------------------------------

            // referencia típus 
            ref ExampleClass visszaClass = ref Program.GetItem1(2);

            ref ExampleClass visszaRef = ref Program.GetItem1(1);
            ExampleClass visszaRef2 = Program.GetItem1(2);

            Console.WriteLine(visszaRef.Property1);
            Console.WriteLine(visszaRef2.Property1);

            visszaRef = new ExampleClass { Property1 = 200 };
            visszaRef2 = new ExampleClass { Property1 = 300 };

            Console.WriteLine($"{ec[0].Property1} {ec[1].Property1} {ec[2].Property1}");


            // érték típus 

            ref int vissza = ref Program.GetItem2(1);
            int vissza2 = Program.GetItem2(2);

            Console.WriteLine(vissza);
            Console.WriteLine(vissza2);

            vissza = 200;
            vissza2 = 300;

            Console.WriteLine($"{el[0]} {el[1]} {el[2]}");


            // ---------------------------------------  --------------------------------------------------------


            Console.ReadKey();
        }




        public static ref ExampleClass GetItem1(int number)
        {
            return ref ec[number];
        }


        public static ref int GetItem2(int number)
        {
            return ref el[number];
        }



    }
}
