using System;
using System.Collections.Generic;

namespace Equality
{
    public class Program
    {
        public static void Main()
        {
            int i = 10;
            int j = 10;
            Console.WriteLine(ReferenceEquals(i, j));
            Console.WriteLine(Equals(i, j));
            Console.WriteLine(i.Equals(j));
            Console.WriteLine(i == j);


            Console.WriteLine(Environment.NewLine);


            Ember emb1 = new Ember() { Name = "Kriszti" };
            Ember emb2 = new Ember() { Name = "Kriszti" };
            Console.WriteLine(ReferenceEquals(i, j));
            Console.WriteLine(Equals(emb1, emb2));
            Console.WriteLine(((object)emb1).Equals(emb2));
            Console.WriteLine(emb1.Equals(emb2));
            Console.WriteLine(emb1 == emb2);

            // -----------------equality with contains----------------------------------------------------------------------

            List<object> emberekObj = new List<object> { new Ember { Name = "Józsi" }, new Ember { Name = "Kriszti" }, new Ember { Name = "Béla" } };
            bool conatinsObj = emberekObj.Contains(new Ember { Name = "Józsi" });

            List<Ember> emberek = new List<Ember> { new Ember { Name = "Józsi" }, new Ember { Name = "Kriszti" }, new Ember { Name = "Béla" } };
            bool conatins = emberek.Contains(new Ember { Name = "Józsi" });

            emberek.Sort();
            emberek.Sort(new EmberComparer());

            //------hash-----------------------------------------------------

            HashSet<Ember> emberHash = new HashSet<Ember>(/*new EmberEquality()*/);
            Ember jozsi = new Ember { Name = "Józsi" };
            emberHash.Add(jozsi);
            emberHash.Add(jozsi);
            emberHash.Add(new Ember { Name = "Józsi" });


            // -----------SortedSet---------------------------------------------------------------------------------------------

            SortedSet<Ember> emberSortedSet = new SortedSet<Ember>();
            emberSortedSet.Add(jozsi);
            emberSortedSet.Add(jozsi);
            emberSortedSet.Add(new Ember { Name = "Józsi" });

            Console.ReadKey();
        }
    }
}
