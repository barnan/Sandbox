using System;
using System.Text;

namespace Investigate_WeakReference
{
    class Program
    {
        static void Main(string[] args)
        {

            WeakReference wr = new WeakReference(new StringBuilder());

            var targetData = wr.Target as StringBuilder;
            targetData?.Append("Ha Ha, He He, Hi Hi");

            Console.WriteLine($"1. isalive: {wr.IsAlive}");         // debugban máshogy megy a GC optimalizálása. Debugban -> True, True, Releaseben -> True, False
            Console.WriteLine(targetData.ToString());

            GC.Collect();

            Console.WriteLine($"2. isalive: {wr.IsAlive}");

            Console.ReadKey();
        }
    }
}
