using System;

namespace Investigate_CovaAndContra
{
    class Program
    {
        static void Main(string[] args)
        {
            // --------------------------------- delegates: --------------------------------------

            Func<IInterfaceBase, IInterfaceDerived1> func01 = new Func<IInterfaceBase, IInterfaceDerived1>((IInterfaceBase input) => new ClasseDerived1());

            // Covariance: 
            Func<IInterfaceBase, IInterfaceBase> func02 = func01;

            // Contravariance: 
            Func<IInterfaceDerived2, IInterfaceDerived1> func03 = func01;


            // -------------------------------- Generics: --------------------------------------

            // ez nem kovariáns interface, hanem invariáns:
            IGenericInterface1<IInterfaceDerived1, IInterfaceDerived1> value01 = new ClassGeneric1();
            //IGenericInterface1<IInterfaceDerived1, IInterfaceBase> value02 = new ClassGeneric1();    // --> ez fordítsi hibát ad, mert nem kovariáns
            //IGenericInterface1<IInterfaceDerived2, IInterfaceBase> value03 = new ClassGeneric1();    // --> ez fordítsi hibát ad, mert nem kontravariáns



            // kova és kontravariáns:
            IGenericInterface2<IInterfaceDerived1, IInterfaceDerived1> covandcontra01 = new ClassGeneric2();
            IGenericInterface2<IInterfaceDerived1, IInterfaceBase> covandcontra02 = new ClassGeneric2();
            IGenericInterface2<IInterfaceDerived2, IInterfaceDerived1> covandcontra03 = new ClassGeneric2();


            Console.ReadKey();
        }


    }
}
