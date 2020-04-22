using System;
using System.Threading.Tasks;

namespace Investigate_Threading
{
    static class Study_MemoryBarrier
    {

        /// <summary>
        /// memory barriers:
        /// </summary>
        static int x = 0;
        static int y = 0;
        static int r1 = 0;
        static int r2 = 0;
        internal static void Prog15()
        {
            int counter = 0;
            do
            {
                Console.WriteLine($"{counter}");

                x = y = r1 = r2 = 0;
                var t1 = new Task(() => { Thread1(); });
                var t2 = new Task(() => { Thread2(); });
                t1.Start();
                t2.Start();
                Task.WaitAll(t1, t2);

                counter++;

            }
            while (r1 != 0 || r2 != 0);                             // csak az utasítások sorrendjének megvoltoztatásával érhető el, hogy mind a kettő nulla legyen
            // a fordító ezt néha megteszi (a volatile se segít ezen)

            Console.WriteLine("r1={0}, r2={1}", r1, r2);
        }
        public static void Thread1()
        {
            y = 1;  // Store y
            //Thread.MemoryBarrier();       // --> így nem cserélődik fel az utasítás
            r1 = x; // Load x            
        }
        public static void Thread2()
        {
            x = 1;  // Store x
            //Thread.MemoryBarrier();       // --> így nem cserélődik fel az utasítás
            r2 = y; // Load y     
        }

    }
}
