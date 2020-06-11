using System;
using System.IO;
using System.Reflection;

namespace DotNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string path = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;

            Ember ember = new Ember();
            ember.DoSomething();
        }
    }
}
