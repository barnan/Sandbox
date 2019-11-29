using System;
using System.Diagnostics;


namespace Conditional
{


    class Valami
    {
        public string Title { get; set; }

        public bool Init()
        {
            return false;
        }


    }



    class Program
    {

        static void Main(string[] args)
        {
            DoSomethingWithEven(1);

            Valami val = new Valami();

            if (val != null && !val.Init())
            {
                throw new Exception(val.Title + " Initialization failed");
            }


            Console.ReadKey();
        }


        [Conditional("DEBUG")]
        public static void DoSomethingWithEven(int input)
        {
            DebugLogger.Message1("páros vagy páratlan lesz", TraceLevel.Info);

            if (input % 2 == 0)
            {
                Console.WriteLine("páros");
                return;
            }

            DebugLogger.Message1("Páratlan - indent 0", TraceLevel.Verbose);
            Debug.Indent();
            DebugLogger.Message1("Páratlan - indent 1", TraceLevel.Verbose);


            Debug.Fail("páratlan - fail");         // messageboxot dob fel abort-retry-ignore opciókkal

            Debug.Assert(input % 2 == 0, "páratlan - assert");      // csinál egy feltétel vizsálatot, ha az false -> akkor jön egy Debug.Fail() 

            Console.WriteLine("páratlan");
        }

    }
}
