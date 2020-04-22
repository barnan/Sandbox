using System;
using System.Threading;

namespace Investigate_Threading
{
    static class Study_Thread
    {

        /// <summary>
        /// threadname, thread properties, threadstart
        /// </summary>
        internal static void Prog01()
        {
            Thread thread1 = new Thread(new ThreadStart(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.Write("y");
                }
            }));                                // a ThreadStart tul képpen egy delegate. a ParameterizedThreadStart pedig egy paraméteres delegate (object)
            thread1.IsBackground = false;       // így nem áll le az app, ha még fut
            thread1.Name = "y thread";          // csak egyszer adható neki név
            thread1.Start();                    // mindegyik thread-nek saját stack-je (lokális változói vannak) van, a heap-en osztoznak. a catched variable-k is a heap-re kerülnek ki
            Console.WriteLine($"{thread1.ManagedThreadId} {thread1.IsThreadPoolThread} {thread1.ThreadState} ");

            for (int i = 0; i < 100; i++)
            {
                Console.Write("x");
            }
        }


        /// <summary>
        /// catch variables in thread
        /// </summary>
        internal static void Prog02()            // variable catching -> külső hivatkozott változók (hiába ValueType-ok) a heap-re kerülnek. És itt mind a két szál írhatja
        {
            int szamlalo = 0;
            int limit = 10;

            Thread thread1 = new Thread(new ThreadStart(() =>
            {
                for (; szamlalo < limit; szamlalo++)
                {
                    Console.Write("?");
                }
            }));
            thread1.Start();

            for (; szamlalo < limit; szamlalo++)
            {
                Console.Write("?");
            }
        }


        /// <summary>
        /// locking
        /// </summary>
        internal static void Prog03()                    // ha nincs lock-olva, nemtudni, h melyik írja/elenőrzi előbb
        {                                               // ha el van látva lock-al -> akkor mindig csak egyszer írja ki.
            bool todo = true;
            object obj = new object();

            Thread thread1 = new Thread(new ThreadStart(() =>
            {
                lock (obj)
                {
                    if (todo)
                    {
                        Console.WriteLine("done");
                        todo = false;
                    }
                }
            }));
            thread1.Start();

            lock (obj)
            {
                if (todo)
                {
                    Console.WriteLine("done");
                    todo = false;
                }
            }
        }


        /// <summary>
        /// Sleep, Join
        /// </summary>
        internal static void Prog04()
        {
            int time1 = 3000;
            int time2 = 4000;

            Thread thread1 = new Thread(new ThreadStart(() =>
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} started");
                Thread.Sleep(time1);
                Console.WriteLine($"{Thread.CurrentThread.Name} ended");
            }));
            thread1.IsBackground = false;
            thread1.Name = "thread1";
            thread1.Start();

            bool resu = thread1.Join(time2);             // a Join bevárja a szállat, kivéve ha lejár a timeout

            Console.WriteLine($"{thread1.Name} {(resu ? "finished" : "not finished")}. It's state is: {thread1.ThreadState}");
        }


        /// <summary>
        /// threadstart, parameterized threadstart
        /// </summary>
        internal static void Prog05()            // az egyik delegate-nek van paramétere, a másiknak nincs
        {
            Thread thread1 = new Thread(new ThreadStart(() =>
            {
                Console.WriteLine("De szép napunk van ma.");
            }));
            thread1.Start();

            Thread thread2 = new Thread(new ParameterizedThreadStart((object obj) =>
            {
                Console.WriteLine($"De szép napunk van ma {obj}-n.");
            }));
            thread2.Start("szerda");

            thread1.Join();
            thread2.Join();
        }


        /// <summary>
        /// Exception handling in thread
        /// </summary>
        internal static void Prog06()
        {
            Thread thread1 = new Thread(new ThreadStart(() =>
            {
                Console.WriteLine("Mindjárt jön az exception");
                throw new Exception("It is comming from the thread.");      // kezeletlen exception a szálon -> leáll az alkalmazás
            }));

            try
            {

                thread1.Start();
            }
            catch (Exception ex)
            {
                ;       // ide nem fut be, leáll az alkalmaás, a thread-en belül lévő exception nem jut ki
            }

            thread1.Join();
        }

    }
}
