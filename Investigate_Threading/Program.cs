using System;
using System.Threading;
using System.Threading.Tasks;

namespace Investigate_Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            //Prog01();
            //Prog02();
            //Prog03();
            //Prog04();
            //Prog05();
            //Prog06();
            //Prog07();
            //Prog08();
            Prog09();
            Prog10();


            Console.ReadKey();

        }


        /// <summary>
        /// threadname, thread properties, threadstart
        /// </summary>
        private static void Prog01()
        {
            Thread thread1 = new Thread(new ThreadStart(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.Write("y");
                }
            }));                                // a ThreadStart tul képpen egy delegate. a ParameterizedThreadStart pedig egy paraméteres delegate (object)
            thread1.IsBackground = false;
            thread1.Name = "y thread";
            thread1.Start();                    // mindegyik thread-nek saját stack-je (lokális változói vannak) van.
            Console.WriteLine($"{thread1.ManagedThreadId} {thread1.IsThreadPoolThread} {thread1.ThreadState} ");

            for (int i = 0; i < 100; i++)
            {
                Console.Write("x");
            }
        }


        /// <summary>
        /// catch variables
        /// </summary>
        private static void Prog02()            // külső hivatkozott változók (hiába ValueType-ok) a heap-re kerülnek. És itt mind a két száll írja
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
        private static void Prog03()                    // ha nincs le-lock-olva, nemtudni, h melyik írja/elenőrzi előbb
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
        private static void Prog04()
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


        //threadstart, parameterized threadstart
        private static void Prog05()            // az egyik delegate-nek van paramétere, a másiknak nincs
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
        private static void Prog06()
        {
            Thread thread1 = new Thread(new ThreadStart(() =>
            {
                Console.WriteLine("Mindjárt jön az exception");
                throw new Exception("It is comming from the thread.");
            }));

            try
            {

                thread1.Start();
            }
            catch (Exception ex)
            {
                ;       // ide nem fut be, leáll az alkalmaás, a thread-en belül lévő száll nem jut ki
            }

            thread1.Join();
        }

        /// <summary>
        /// Task API
        /// </summary>
        private static void Prog07()
        {
            Task task01 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Task paraméter és visszatéréis érték nélkül indul");
                Thread.Sleep(3000);
                Console.WriteLine("Task paraméter és visszatéréis érték nélkül végetér");
            });

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
        private static void Prog08()
        {
            try
            {
                Task<int> task01 = Task<int>.Factory.StartNew(() =>
                   {
                       Console.WriteLine("Task exception előtt");
                       throw new Exception();
                   });
                Console.WriteLine($"{task01.Result}");                      // a Result lekéréskor újradobja a szálban keletkezett kivételt
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception elkapva {ex.Message}");
            }
        }


        /// <summary>
        /// QueueUserWorkItem
        /// </summary>
        private static void Prog09()
        {
            ThreadPool.QueueUserWorkItem((object obj) =>
            {
                Console.WriteLine($"Task exception előtt: {obj}");

            }, 123);


        }


        /// <summary>
        /// QueueUserWorkItem Exception
        /// </summary>
        private static void Prog10()
        {
            ThreadPool.QueueUserWorkItem((object obj) =>
            {
                Console.WriteLine("Task exception előtt ");
                //throw new Exception();                                // QueueUserWorkItem-ben kezeletlen kivétel miatt leáll az alkalmazás!!!

            });

        }

    }
}

