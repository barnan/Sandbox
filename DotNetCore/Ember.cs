using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace DotNetCore
{
    interface IZoldFuloEmber
    {
        string NickName { get; set; }
    }



    class Ember
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public void DoSomething([CallerMemberName] string name = "")
        {
            var szoveg = new StackTrace();
            Console.WriteLine(name + szoveg);
        }
    }
}
