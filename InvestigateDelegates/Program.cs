using System;
using System.Reflection;

namespace InvestigateDelegates
{
    class Program
    {

        public static int DoSomething(int eletkor, string nev)
        {
            return nev.Length + eletkor;
        }

        public static int DoSomething(Ember ember)
        {
            return ember.Nev.Length + ember.Eletkor;
        }


        delegate int Fuggveny1(int input1, string input2);
        delegate int Fuggveny2(Ember ember);
        delegate int Fuggveny3();
        delegate int Fuggveny4(Ember emb, int input);


        static void Main(string[] args)
        {
            Ember emb1 = new Ember("HeHe", 30);
            Ember emb2 = new Ember("HeHeHe", 40);


            // nyitott delegate static metódusra: --------------------------------------------------
            Fuggveny1 fu1 = DoSomething;

            Console.WriteLine(fu1(emb1.Eletkor, emb1.Nev));

            // nyitott delegate static metódusre CreateDelegate-tel:--------------------------------
            MethodInfo[] mis = typeof(Program).GetMethods();
            Fuggveny2 fu2 = (Fuggveny2)Delegate.CreateDelegate(typeof(Fuggveny2), mis[1]);

            Console.WriteLine(fu2(emb1));


            // zárt delegate példány metódusra:-----------------------------------------------------
            Fuggveny3 fu3 = emb2.DoSomething;

            Console.WriteLine(fu3());


            // methodinfo hívás mindig más objektumra: --------------------------------------------
            MethodInfo mi1 = typeof(Ember).GetMethod("DoSomething");        // ez lassú a reflection miatt, de futásközben gyorasabb leht, nem kell mindig új delegate-et létrehozni
            Func<object, object> fu4 = o => mi1.Invoke(o, null);

            Console.WriteLine(fu4(emb2));


            // nyitott delegate példány metódusra: -------------------------------------------------
            MethodInfo mi2 = typeof(Ember).GetMethod("DoSomething3");
            Fuggveny4 fu5 = (Fuggveny4)Delegate.CreateDelegate(typeof(Fuggveny4), null, mi2);   // itt meg kell adni a null -objektumot is!!!! A delegate signatúrájában benne van az ember, híváskor viszont nem kell megadni!!!

            Console.WriteLine(fu5(emb2, 10));


            Console.ReadKey();
        }
    }
}
