using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Inlining
{
    class Program
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static int A(int v)
        {
            // This is a single method call.
            // ... It contains twenty increments.
            v++; v++; v++; v++; v++; v++; v++; v++; v++; v++;
            v = C(v);
            return v;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        static int B(int v)
        {
            // This does ten increments.
            // ... Then it does ten more increments in another method.
            v++; v++; v++; v++; v++; v++; v++; v++; v++; v++;
            v = C(v);
            return v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static int C(int v)
        {
            // This does ten increments.
            v++; v++; v++; v++; v++; v++; v++; v++; v++; v++;
            return v;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        static int D(int v)
        {
            // This does ten increments.
            v++; v++; v++; v++; v++; v++; v++; v++; v++; v++;
            return v;
        }

        static void Main()
        {
            const int max = 100000000;
            int temp1 = 0;
            int temp2 = 0;
            //A(0);
            B(0);
            //C(0);
            D(0);



            var s1 = Stopwatch.StartNew();
            for (int i = 0; i < max; i++)
            {
                temp1 = A(i);
            }
            s1.Stop();


            var s2 = Stopwatch.StartNew();
            for (int i = 0; i < max; i++)
            {
                temp2 = B(i);
            }
            s2.Stop();



            Console.WriteLine(s1.Elapsed.TotalMilliseconds * 1000 * 1000 / (double)max);
            Console.WriteLine(s2.Elapsed.TotalMilliseconds * 1000 * 1000 / (double)max);
            Console.WriteLine("{0} {1}", temp1, temp2);

            Console.ReadKey();
        }
    }

    //class Program
    //{
    //    const int _max = 10000000;
    //    static void Main()
    //    {
    //        // ... Compile the methods.
    //        Method1();
    //        Method2();
    //        int sum = 0;

    //        var s1 = Stopwatch.StartNew();
    //        for (int i = 0; i < _max; i++)
    //        {
    //            sum += Method1();
    //        }
    //        s1.Stop();
    //        var s2 = Stopwatch.StartNew();
    //        for (int i = 0; i < _max; i++)
    //        {
    //            sum += Method2();
    //        }
    //        s2.Stop();
    //        Console.WriteLine(((double)(s1.Elapsed.TotalMilliseconds * 1000000) /
    //                           _max).ToString("0.00 ns"));
    //        Console.WriteLine(((double)(s2.Elapsed.TotalMilliseconds * 1000000) /
    //                           _max).ToString("0.00 ns"));
    //        Console.ReadKey();
    //    }


    //    static int Method1()
    //    {
    //        // ... No inlining suggestion.
    //        return "one".Length + "two".Length + "three".Length +
    //               "four".Length + "five".Length + "six".Length +
    //               "seven".Length + "eight".Length + "nine".Length +
    //               "ten".Length;
    //    }

    //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //    static int Method2()
    //    {
    //        // ... Aggressive inlining.
    //        return "one".Length + "two".Length + "three".Length +
    //               "four".Length + "five".Length + "six".Length +
    //               "seven".Length + "eight".Length + "nine".Length +
    //               "ten".Length;
    //    }
    //}

}
