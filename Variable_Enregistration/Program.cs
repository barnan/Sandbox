using System;
using System.Diagnostics;

namespace Variable_Enregistration
{
    class App
    {
        static void Main()
        {
            Console.WriteLine(int.MaxValue);

            int decimalPlace_0 = 5;
            int decimalPlace_1 = 4;
            int decimalPlace_2 = 8;
            int decimalPlace_3 = 0;

            int result = (decimalPlace_3 << 12) + (decimalPlace_2 << 8) + (decimalPlace_1 << 4) + decimalPlace_0;



            const Int64 iter = 500000000;
            
            Stopwatch sw1 = Stopwatch.StartNew();
            TestFieldAccess(iter);
            Console.WriteLine("time taken:{0} ticks", sw1.Elapsed);

            Stopwatch sw2 = Stopwatch.StartNew();
            TestLocalAccess(iter);
            Console.WriteLine("time taken:{0} ticks", sw2.Elapsed);

            Console.ReadKey();
        }

        private static Int64 _j;


        // local variable can be registered.
        public static void TestLocalAccess(Int64 numIncrement)
        {
            Int64 k = 0;
            for (Int64 i = 0; i < numIncrement; i++)
            {
                k++;
            }
        }

        public static void TestFieldAccess(Int64 numIncrement)
        {
            for (Int64 i = 0; i < numIncrement; i++)
            {
                _j++;
            }
        }
    }
}
