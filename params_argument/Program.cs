using System;

namespace params_argument
{
    class Program
    {

        static void fuggveny(string elso, double masodik, params int[] parameterek)
        {
            Console.WriteLine(elso);
            Console.WriteLine(masodik);
            Console.WriteLine(string.Join(",", parameterek));
        }


        static void fuggveny2(string elso, string masodik = "1.1", int harmadik = 1)
        {
            Console.WriteLine(elso);
            Console.WriteLine(masodik);
            Console.WriteLine(harmadik);
        }


        static void fuggveny3(params object[] input)
        {
            foreach (object obj in input)
            {
                Console.WriteLine(obj);
            }
        }



        static void Main(string[] args)
        {
            fuggveny3(20);

            fuggveny("hehe", 1.3, 1, 2, 3, 4, 5, 6, 7, 8, 9);


            fuggveny2("hehe", harmadik: 7, masodik: "1.7");


            Ember emb1 = new Ember { Text = "vmi" };
            Ember emb2 = null;
            Console.WriteLine(Convert.ToString(emb1));
            Console.WriteLine(emb1.ToString());


            Console.ReadKey();
        }
    }
}
