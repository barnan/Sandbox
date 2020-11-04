using System;

namespace stringek
{
    class Program
    {
        static void Main(string[] args)
        {
            //------------------- string literálok, intern: ------------------------------------------

            string lit1 = "Norbi fasza gyerek 5";
            int valtozo1 = 3;

            string str1 = $"Norbi fasza gyerek {3}";
            string str2 = $"Norbi fasza gyerek {valtozo1}";

            Console.WriteLine(string.IsInterned(lit1));
            Console.WriteLine(string.IsInterned(str1) ?? "false");
            Console.WriteLine(string.IsInterned(str2) ?? "false");

            // ------------ string format ---------------------------------------

            string formatString = "HeHe_0: {0}, HeHe_1: {1}";
            Func1(formatString, 45, 48, 34);

            // ---------- comparálás -----------------------------------------

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

           
            string checkSumString = "Checksum=\"";
            string input1 = "<Configuration ModifiedBy=\"SAM_SUITE, Version = 2.0.0.0\" Checksum=\"\">";
            string[] lineParts = input1.Split(new string[] { checkSumString }, StringSplitOptions.RemoveEmptyEntries);

            string newLine = $"{lineParts[0]} {checkSumString}kolikasmacska78{lineParts[1]}";

            Console.ReadKey();

        }

        static void Func1(string formatString, params object[] parameters)
        {
            Console.WriteLine(string.IsInterned(formatString) ?? "false");

            Console.WriteLine(string.Format(formatString, parameters));
        }
    }
}
