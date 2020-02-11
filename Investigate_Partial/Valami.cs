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
            Console.WriteLine("valami DoSomething 1");          // egyszerre csak egy implementáció lehet
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

}
