using System;

namespace Investigate_Partial
{

    internal class BaseClass1
    {
        private int Proper { get; set; }
    }


    internal class BaseClass2
    {
        private string Prop { get; set; }
    }



    internal partial class Valami : BaseClass1          // több helyen is meg lehet adni baseclass-t de annak ugyannak kell lennie, így sem lehet több őse, mint 1
    {

        partial void DoSomething()
        {
            Console.WriteLine("valami DoSomething 1");          // egyszerre csak egy implementáció lehet. Ha nincs implementálva sehol, kihagyja, de nem dob hibát!!!
        }
    }



    internal partial class Valami : BaseClass1
    {
        partial void DoSomething();


        public void DoSomething2()
        {
            DoSomething();
        }

    }

    //*********************** struct ***********************************
    public partial struct ExampleStruct1                // struct is lehet partial!!
    {
        private int field1;
    }


    public partial struct ExampleStruct1
    {
        private int field2;

        public ExampleStruct1(int input1, int input2)
        {
            field1 = input1;
            field2 = input2;                // a ctor-nak továbbra is az össze field-et inicializálnia kell!!!!
        }
    }
}
