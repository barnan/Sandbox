using System;
using System.CodeDom;
using System.ComponentModel;
using System.Drawing;

namespace GC
{
    class Program
    {
        static Point p;


        static void Main(string[] args)
        {

            Console.WriteLine(System.GC.MaxGeneration);

            System.GC.Collect(2);


            Console.WriteLine(System.GC.CollectionCount(0));
            Console.WriteLine(System.GC.CollectionCount(1));
            Console.WriteLine(System.GC.CollectionCount(2));

            
            

            Console.WriteLine(p == default(Point));


            Console.ReadKey();
        }
    }
}
