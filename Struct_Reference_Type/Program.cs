using System;

namespace Struct_Reference_Type
{
    class Program
    {
        static void Main(string[] args)
        {
            struct01 struktura1 = new struct01 { Ref02 = new Reference02 { IntValtozo = 10, StringValtozo = "Belső Ref02" }, IntValtozo1 = 20 };            // ez foglalódik a stack-en, ez a struct tartalmaz ref változót

            struct01 struktura2 = struktura1;           // egy deep copy keletkezik a structról, de a benne lévő referenciáról CSAK SEKÉLY
            struktura1.IntValtozo1 = 40;                   // csak az eredetit módosítja, mert erről ugye deep copy keletkezik
            struktura1.Ref02.IntValtozo = 10000000;       // módosítja az eredetit és a lemásolt struct-ban lévő referencia változót is



            Reference01 ref01 = new Reference01 { Szoveg = "Reference01", Struktura = struktura1 };                                             // param átadás miatt a struct lemásolódik (deep copy), de az új már a heap-en lesz

            struct01 struktura20 = ref01.Struktura;         // itt is teljes másolat keletkezik a struct-ról, kivéve a benne lévő ref változót

            Reference01 ref11 = ref01;
            ref01.Szoveg = "eredeti";
            ref01.Struktura.Ref02.IntValtozo = -1000000;
            ref01.Struktura.IntValtozo1 = 2000000;


            // --------------GetHashcode() ---------------------------------------------------------------------

            Console.WriteLine(struktura1.GetHashCode());                        // a struct Hash kódja a benne lévő field-ekből számolódik ki --> ha azok változnak változik a a HashCode!!!
            Console.WriteLine(struktura1.IntValtozo1.GetHashCode());

            struktura1.IntValtozo1 = 500000;

            Console.WriteLine(struktura1.GetHashCode());
            Console.WriteLine(struktura1.IntValtozo1.GetHashCode());

            Console.WriteLine(struktura1.Ref02.GetHashCode());


            structMasik masik = new structMasik();
            masik.IntValtozo1 = 10;
            masik.IntValtozo2 = 20;

            Console.WriteLine(masik.GetHashCode());

            masik.IntValtozo1 = 100;                // megváltozik a hash kódja a struct-nak, azzal hogy egy fieldjét módosítjuk

            Console.WriteLine(masik.GetHashCode());

            // --------------nullable value type ---------------------------------------------------------------------

            struct01? nullablestruct = struktura1;
            Nullable<struct01> nullableStruct2 = nullablestruct;

            struct01 stru = nullablestruct.Value;                   // minden Nullable értéktípus a Nullable<T>-ből származik
            Console.WriteLine(nullablestruct);


            int? int01 = 10;
            int? int02 = int01;                     // a nullable<T> az egy struct, teljes másolat keletkezik róla
            int02 = null;

            // --------------nullable boxing ---------------------------------------------------------------------

            object obj01 = int01;

            Console.WriteLine((int)obj01);          // fontos!!! boxing-kor az érték csomagolódik csak, kicsomagolás is lehetséges az eredeti típusra!!!
            Console.WriteLine((int?)obj01);         // fontos!!! tehát itt exception-t dob


            int? k = 30;
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
