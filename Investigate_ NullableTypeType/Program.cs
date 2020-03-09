using System;

namespace Investigate__NullableTypeType
{
    class Program
    {
        static void Main(string[] args)
        {

            // --------------nullable value type ---------------------------------------------------------------------

            struct01? nullablestruct = new struct01();
            Nullable<struct01> nullableStruct2 = nullablestruct;            // minden Nullable értéktípus a Nullable<T>-ből származik, struct-ok is!!!!!

            struct01 stru = nullablestruct.Value;
            Console.WriteLine(nullablestruct);


            int? int01 = 10;
            int? int02 = int01;                     // a nullable<T> az egy struct, teljes másolat keletkezik róla átadáskor
            int02 = null;

            // --------------nullable boxing ---------------------------------------------------------------------

            object obj01 = int01;

            Console.WriteLine((int)obj01);          // fontos!!! boxing-kor az érték csomagolódik csak, kicsomagolás is lehetséges az eredeti típusra!!!   vagy annak a nullable változatára
            Console.WriteLine((int?)obj01);         // fontos!!! nem dob exceptiont
            //Console.WriteLine((long)obj01);         // fontos!!! tehát itt exception-t dob

            int k = 30;
            int? knull = k;

            Console.WriteLine($"Equals: {k == knull}");
            Console.WriteLine(IsOfNullableType(k));



            Console.ReadKey();
        }



        static bool IsOfNullableType<T>(T o)
        {
            var type = typeof(T);
            return Nullable.GetUnderlyingType(type) != null;
        }

    }
}
