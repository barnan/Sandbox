using System;

namespace Investigate_Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            // ******************************************************* anonym type ******************************************************************

            var anonim01 = new { Prop01 = 10, Prop02 = 30, Prop03 = "valami" };             // anoním típus -> referencia típus, system.object-ből származik, tul. képpen immutable (readonly) property-k gyűjteménye
            var anonim02 = new { Prop01 = 11, Prop02 = 1f, Prop03 = "val" };
            var anonim03 = new { Prop01 = 11, Prop02 = 1d, Prop03 = "val" };
            var anonim04 = new { Prop01 = 11, Prop02 = 1d, Prop03 = "val" };

            Console.WriteLine($"Equals: {Equals(anonim04, anonim03)}");                       // egyenlő a két anoním típusú változó
            Console.WriteLine($"Equals: {Equals(anonim02, anonim03)}");                       // itt nem egyenlő( egyk float másik double)


            // ******************************************************* c# 7.0 előtt ******************************************************************

            Tuple<int, int, string> tuple01 = new Tuple<int, int, string>(10, 20, "fdsfd");     // ValueTupple nélkül ez működik
            Tuple<int, int, string> tuple02 = Tuple.Create(10, 20, "fdsfd");                    // ValueTupple nélkül ez működik

            Console.WriteLine($"Equals: {Equals(tuple01, tuple02)}");                       // egyenlő a két tuple


            // ******************************************************* value tuple ******************************************************************

            (int Alpha, int Beta, string Gamma) namedTuple1 = (10, 30, "valami");
            var namedTuple2 = (Alpha: "a", Beta: "b");
            var namedTuple3 = namedTuple2;

            Console.WriteLine($"Equals: {Equals(namedTuple1, tuple01)}");                       // nem egyenlő a két tuple, az egyik sima Tuple, amásik ValueTuple
            Console.WriteLine($"Equals: {Equals(namedTuple1, namedTuple2)}");                   // itt egyenlő a két named tuple

            namedTuple2.Alpha = "norbika";                 // értéktípus, átadáskor teljes másolat keletkezik


            // *************************************************************************************************************************


            Console.ReadKey();
        }
    }
}
