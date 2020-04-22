using System;
using System.Threading;
using System.Threading.Tasks;

namespace Investigate_Threading
{
    static class Study_TaskAPI
    {

        /// <summary>
        /// Task API
        /// </summary>
        internal static void Prog07()
        {
            Task task01 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Task paraméter és visszatérési érték nélkül indul");
                Thread.Sleep(3000);
                Console.WriteLine("Task paraméter és visszatérési érték nélkül végetér");
            });

            // paraméteres task
            Task<int> task02 = Task<int>.Factory.StartNew(() =>
            {
                Console.WriteLine("Task visszatérési értékkel indul.");
                Thread.Sleep(2000);
                Console.WriteLine("Task visszatérési értékkel végetér.");
                return 10;
            });

            task02.Wait(1000);

            Thread.Sleep(4000);

            if (task01.IsCompleted)
            {
                Console.WriteLine(task02.Result);
            }

        }


        /// <summary>
        /// Task exception
        /// </summary>
        internal static void Prog08()
        {
            Task<int> task01 = new Task<int>(() =>
            {
                Console.WriteLine("Task exception előtt");
                throw new Exception();
            });

            try
            {
                task01.Start();
                Console.WriteLine($"{task01.Result}");                      // a Result lekéréskor újradobja a szálban keletkezett kivételt
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception elkapva {ex.Message}");
            }
        }

    }
}
