using System;
using System.Threading;
using static Investigate_Threading.Study_MonitorWaitPulse;

namespace Investigate_Threading
{

    class Program
    {

        static void Main(string[] args)
        {
            int? val = null;
            string valami = $"valami {null}, {val.ToString()}";


            // thread:
            //Prog01();
            //Prog02();
            //Prog03();
            //Prog04();
            //Prog05();
            //Prog06();

            // task API
            //Prog07();
            //Prog08();

            // QueueUserWorkItem
            //Prog09();
            //Prog10();


            //async delegate
            //Prog11();
            //Prog12();

            // background worker:
            //Prog13();

            // lazy
            //Prog14();

            //MemoryBarrier:
            //Prog15();

            // Monitor Wait Pulse, AutoResetEvent
            Prog17();
            Prog18();


            Thread.Sleep(10000);

            Console.ReadKey();

        }




      



        /// <summary>
        /// Parallel class - task creation and run
        /// </summary>
        void Prog19()
        {

        }



        /// <summary>
        /// Parallel class - creational options, LongRun, PreferFairness, AttchedToParent
        /// </summary>
        void Prog20()
        {

        }


    }
}

