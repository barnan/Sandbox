using System;
using System.Threading;

namespace Investigate_Threading
{
    static class Study_QueueUserWorkItem
    {
        /// <summary>
        /// ThreadPool QueueUserWorkItem
        /// </summary>
        internal static void Prog09()
        {
            ThreadPool.QueueUserWorkItem((object obj) =>
            {
                Console.WriteLine($"QueueUserWorkItem, átadott state: {obj}");         // a QueueUserWorkItem-nek is adható át input paraméter (state-ként egy object). Így ez nem típusos
            }, 123);
        }


        /// <summary>
        /// ThreadPool QueueUserWorkItem Exception
        /// </summary>
        internal static void Prog10()
        {
            ThreadPool.QueueUserWorkItem((object obj) =>
            {
                Console.WriteLine("QueueUserWorkItem exception előtt");
                throw new Exception();                                              // QueueUserWorkItem-ben kezeletlen kivétel miatt leáll az alkalmazás!!! (nem továbbítja a kivételt)
            });
        }

    }
}
