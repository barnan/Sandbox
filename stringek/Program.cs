using System;

namespace stringek
{
    class Program
    {
        static void Main(string[] args)
        {

            //-------------------string literálok, intern:------------------------------------------

            string lit1 = "Norbi fasza gyerek 5";
            int valtozo1 = 5;

            string str1 = $"Norbi fasza gyerek {5}";

            Console.WriteLine(string.IsInterned(lit1));
            Console.WriteLine(string.IsInterned(str1) ?? "false");


            // ----------comparálás -----------------------------------------


            string s = "strasse";

            // outputs False:
            Console.WriteLine(s == "straße");
            Console.WriteLine(s.Equals("straße"));
            Console.WriteLine(s.Equals("straße", StringComparison.Ordinal));
            Console.WriteLine(s.Equals("Straße", StringComparison.CurrentCulture));
            Console.WriteLine(s.Equals("straße", StringComparison.OrdinalIgnoreCase));

            // outputs True:
            Console.WriteLine(s.Equals("straße", StringComparison.CurrentCulture));
            Console.WriteLine(s.Equals("Straße", StringComparison.CurrentCultureIgnoreCase));



            Console.ReadKey();
        }
    }
}
