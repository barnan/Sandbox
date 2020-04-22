using System;
using System.Threading;

namespace Investigate_Threading
{
    static class Study_MonitorWaitPulse
    {


        /// <summary>
        /// Monitor Wait and Pulse
        /// </summary>
        private static object _locker = new object();
        private static bool _go = false;
        internal static void Prog17()
        {                                // The new thread will block
            new Thread(Work).Start();     // because _go==false.

            Console.ReadLine();            // Wait for user to hit Enter

            lock (_locker)                 // Let's now wake up the thread by
            {                              // setting _go=true and pulsing.
                _go = true;
                Monitor.Pulse(_locker);
            }
        }

        static void Work()
        {
            lock (_locker)
                while (!_go)                    // ez csak ahhoz kell, hogy a megváltozott változók értékei is használhatóak itt
                    Monitor.Wait(_locker);      // Lock is released while we’re waiting -> ez fontos!!!!

            Console.WriteLine("Woken!!!");
        }




        /// <summary>
        /// AutoResetEvent Monitor.Wait és Monitor.Pulse-al megvalósítva
        /// </summary>
        //static readonly object _locker = new object();
        private static bool _ready; // _go;

        internal static void Prog18()
        {
            new Thread(Work2).Start();

            for (int i = 0; i < 5; i++)
                lock (_locker)
                {
                    while (!_ready)
                        Monitor.Wait(_locker);
                    _ready = false;                 //AutoResetEvent !!
                    _go = true;
                    Monitor.PulseAll(_locker);
                }
        }

        static void Work2()
        {
            for (int i = 0; i < 5; i++)
                lock (_locker)
                {
                    _ready = true;
                    Monitor.PulseAll(_locker);           // Remember that calling
                    while (!_go)
                        Monitor.Wait(_locker);  // Monitor.Wait releases
                    _go = false;                           // and reacquires the lock.
                    Console.WriteLine("Wassup?");
                }
        }
    }
}
