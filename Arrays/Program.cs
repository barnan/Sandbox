using System;
using System.Collections;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {

            // --------Array -------------------------------------------------------------------

            Array arr1 = Array.CreateInstance(typeof(double), 20);      // baseclass-a a clr-ben az összes tömbnek, erősen típusos, bár object tömb esetén bármi pakolható bele
            double[] arr2 = new double[10];
            Array arr3 = arr2;

            // --------------ArrayList-------------------------------------------------------------------

            ArrayList arrlist = new ArrayList();
            arrlist.Add("20");
            arrlist.Add(20);



            Console.ReadKey();
        }
    }
}
