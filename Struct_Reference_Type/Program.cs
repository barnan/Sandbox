using System;

namespace Struct_Reference_Type
{
    class Program
    {
        static void Main(string[] args)
        {
            struct01 struktura1 = new struct01 { Ref02 = new Reference02 { IntValtozo = 1, StringValtozo = "Reference02" }, IntValtozo1 = 2 }; // ez foglalódik a stack-en, ez a struct tartalmaz ref változót

            struct01 struktura2 = struktura1;   // egy deep copy keletkezik a structról, de a benne lévő referenciáról CSAK SEKÉLY
            struktura1.IntValtozo1 = 30;        // csak az eredetit módosítja, mert erről ugye deep copy keletkezik
            struktura1.Ref02.IntValtozo = 100;  // módosítja az eredetit és a lemásolt struct-ban lévő referencia változót is -> a benne lévő referenciáról csak sekély másolat keletkezik!!



            Reference01 ref01 = new Reference01 { Text = "Reference01", Struktura = struktura1 }; // param átadás miatt a struct lemásolódik (deep copy), de az új már a heap-en lesz

            struct01 struktura20 = ref01.Struktura; // itt is TELJES másolat keletkezik a struct-ról, kivéve a benne lévő ref változót

            Reference01 ref11 = ref01;              // ennél a referencia másolatnál csak SEKÉLY másolat keletkezik és a benne lévő struc-tól is csak SEKÉLY másolat
            ref01.Text = "modosított szöveg";
            ref01.Struktura.Ref02.IntValtozo = -1000;
            ref01.Struktura.IntValtozo1 = -2000;

            // --------------GetHashcode() ---------------------------------------------------------------------

            Console.WriteLine(struktura1.GetHashCode()); // a struct Hash kódja a benne lévő field-ekből számolódik ki --> ha azok változnak változik a a HashCode!!!
            Console.WriteLine(struktura1.IntValtozo1.GetHashCode());

            struktura1.IntValtozo1 = 500000;

            Console.WriteLine(struktura1.GetHashCode());
            Console.WriteLine(struktura1.IntValtozo1.GetHashCode());

            Console.WriteLine(struktura1.Ref02.GetHashCode());


            structMasik masik = new structMasik();
            masik.IntValtozo1 = 10;
            masik.IntValtozo2 = 20;

            Console.WriteLine($"struct hash elősször: {masik.GetHashCode()}");
            masik.IntValtozo1 = 100;
            Console.WriteLine($"struct hash másodszor: {masik.GetHashCode()}");     // megváltozik a hash kódja a struct-nak, azzal hogy egy fieldjét módosítjuk

            Reference02 reference02 = new Reference02 { IntValtozo = 30, StringValtozo = "HeHe" };
            Console.WriteLine($"ref hash elősször: {reference02.GetHashCode()}");
            reference02.IntValtozo = 40;
            Console.WriteLine($"ref hash másodszor: {reference02.GetHashCode()}");      // a referencia hash kódja nem változik, azzal hogy a mezőit változtatjuk

          


            Console.ReadKey();
        }

    }
}
