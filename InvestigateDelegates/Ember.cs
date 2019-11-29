namespace InvestigateDelegates
{
    public class Ember
    {

        public static int DoSomething2(int eletkor, string nev)
        {
            return nev.Length + eletkor;
        }



        public Ember(string nev, int eletkor)
        {
            Nev = nev;
            Eletkor = eletkor;
        }

        public string Nev { get; }

        public int Eletkor { get; }


        public int DoSomething()
        {
            return Nev.Length + Eletkor;
        }

        public int DoSomething3(int input)
        {
            return input + Eletkor;
        }

    }
}
