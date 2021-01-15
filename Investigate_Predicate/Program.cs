using System;

namespace Investigate_Predicate
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Action action01 = new Action(Method01);

            Func<bool> func01 = new Func<bool>(Method02);
            Func<bool, string, bool> func02 = new Func<bool, string, bool>(Method03);

            Predicate<string> predicate01 = new Predicate<string>(Method04);

            action01();
            Console.WriteLine(func01());
            Console.WriteLine(func02(false, "hehe"));
            Console.WriteLine(predicate01("hehe"));

            Console.ReadKey();
        }

        private static void Method01()
        {
            Console.WriteLine(nameof(Method01));
        }

        private static bool Method02()
        {
            Console.WriteLine(nameof(Method02));
            return true;
        }

        private static bool Method03(bool input1, string input2)
        {
            Console.WriteLine(nameof(Method03));
            return !input1 && string.IsNullOrEmpty(input2);
        }

        private static bool Method04(string input)
        {
            Console.WriteLine(nameof(Method04));
            return string.IsNullOrEmpty(input);
        }
    }
}