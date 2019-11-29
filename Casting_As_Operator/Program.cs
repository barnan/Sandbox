using System;

namespace Casting_As_Operator
{

    struct struct1
    {
        public int Elso { get; set; }
    }

    struct struct2
    {
        public int Masodik { get; set; }

        public struct2(int masodik)
        {
            Masodik = masodik;
        }

        public static explicit operator struct2(struct1 input)
        {
            return new struct2(input.Elso);
        }
    }



    interface IEmber2
    {
    }


    interface IEmber
    {
        int Height { get; set; }
    }


    class Ember : IEmber
    {
        public int Height { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {

            short szam1 = 1000;
            double doub = 1000000.2;

            byte b = (byte)szam1;
            byte b2 = (byte)doub;           // itt mi lehet a pontos folyamat?

            Ember emb = new Ember();
            IEmber iemb = (IEmber)emb;
            //IEmber2 iemb2 = (IEmber2)emb;   -> ez exception-t dob

            struct1 stru1 = new struct1();
            stru1.Elso = 30;

            struct2 stru2 = (struct2)stru1;  // -> ez már fordítási hibát is ad



            Console.ReadKey();
        }
    }
}
