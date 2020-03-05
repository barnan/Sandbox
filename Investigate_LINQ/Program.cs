using System;
using System.Collections.Generic;
using System.Linq;

namespace Investigate_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lista = new List<int> { 1, 2, 3, 4, 5, 6 };

            var agresult = lista.Aggregate(
                seed: 12,
                func: (result, item) => result + item,
                resultSelector: result => result);



            var agresult2 = lista.Aggregate(
                seed: 0,                                                    // a kező érték
                func: (result, item) => result + item,                      // az aggregátor
                resultSelector: result => (decimal)result / lista.Count);   // egy transzformáció az eredményen

            Console.ReadKey();
        }
    }
}
