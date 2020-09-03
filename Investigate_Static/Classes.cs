namespace Investigate_Static
{
    class Class01
    {
        public int ertek;

        public static Class01 operator +(Class01 elso, Class01 masodik)
        {
            return new Class01 { ertek = elso.ertek + masodik.ertek };
        }


        public static implicit operator int(Class01 elso)
        {
            return elso.ertek;
        }

        public static explicit operator Class01(int szam)
        {
            return new Class01 { ertek = szam };
        }
    }




    static class Class02
    {
        private static int valtozo;


        private static void Method01()
        { }

        private static int Property01 { get; set; }



    }
}
