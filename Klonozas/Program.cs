using System;
using System.Diagnostics;

namespace Klonozas
{

    interface IBaseClass : ICloneable
    {
    }


    interface IDerivedClass : IBaseClass
    {

    }



    class BaseClass : IBaseClass
    {
        int _szam1;
        string _szoveg;

        public object Clone()
        {
            BaseClass bc = new BaseClass();
            bc._szam1 = _szam1;
            bc._szoveg = _szoveg;

            return bc;
        }
    }



    class DerivedClass : BaseClass, IDerivedClass
    {

    }



    class Program
    {
        static void Main(string[] args)
        {

            int x = 10;

            Debug.Assert(x > 10);


            DerivedClass derivedClass = new DerivedClass();
            DerivedClass derivedClass2 = derivedClass.Clone() as DerivedClass;

            Console.ReadKey();
        }
    }
}
