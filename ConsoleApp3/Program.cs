using System;

namespace ConsoleApp3
{

    public class A
    {
        public virtual void DoSomething1()
        {
            Console.WriteLine("A DoSomething 1");
        }

        public virtual void DoSomething2()
        {
            Console.WriteLine("A DoSomething 2");
        }
        public virtual void DoSomething3()
        {
            Console.WriteLine("A DoSomething 3");
        }
    }



    public class B : A
    {
        public new virtual void DoSomething1()
        {
            Console.WriteLine("B DoSomething 1");
        }

        public override void DoSomething2()
        {
            Console.WriteLine("B DoSomething 2");
        }

        public override void DoSomething3()
        {
            Console.WriteLine("B DoSomething 3");
        }
    }


    public class C : B
    {
        public override void DoSomething1()
        {
            Console.WriteLine("C DoSomething 1");
        }

        public new void DoSomething2()
        {
            Console.WriteLine("C DoSomething 2");
        }

        public override void DoSomething3()
        {
            Console.WriteLine("C DoSomething 3");
        }
    }





    class Program
    {
        static void Main(string[] args)
        {
            A aa = new A();
            A ab = new B();
            A ac = new C();

            B bb = new B();
            B bc = new C();

            aa.DoSomething1();
            ab.DoSomething1();
            ac.DoSomething1();
            bb.DoSomething1();
            bc.DoSomething1();

            Console.WriteLine(Environment.NewLine);

            aa.DoSomething2();
            ab.DoSomething2();
            ac.DoSomething2();
            bb.DoSomething2();
            bc.DoSomething2();

            Console.WriteLine(Environment.NewLine);

            aa.DoSomething3();
            ab.DoSomething3();
            ac.DoSomething3();
            bb.DoSomething3();
            bc.DoSomething3();


            Console.ReadKey();

        }
    }
}
