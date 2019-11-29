using System;
using System.Diagnostics;

namespace Exceptions
{

    public class ExceptionThrower
    {
        public void InvalidMethod()
        {
            throw new InvalidOperationException("This method is invalid.");
        }
    }


    public class Layer1
    {
        private ExceptionThrower _thrower;

        public Layer1()
        {
            _thrower = new ExceptionThrower();
        }

        public void Layer1Method()
        {
            _thrower.InvalidMethod();
        }
    }




    public class Layer2
    {
        private Layer1 _layer1;

        public Layer2()
        {
            _layer1 = new Layer1();
        }

        public void Layer2Method()
        {
            try
            {
                _layer1.Layer1Method();
            }
            catch (Exception ex)
            {
                //throw new InvalidOperationException($"laylay2", ex);        //újradobje, a stacktrace eltűnik, de az innerexception-be belekerül a korábbi exception
                throw;                                                      // továbbdobja stacktrace-estől
            }
        }
    }


    class Program
    {

        static void Main(string[] args)
        {
            Debugger.Break();

            try
            {
                Console.WriteLine("Calling KeepStackTrace");
                KeepStackTrace();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.StackTrace);

                if (ex.InnerException != null)
                {
                    Console.WriteLine($"inner: {ex.InnerException}");
                }

            }

            Console.WriteLine(Environment.NewLine);

            try
            {
                Console.WriteLine("Calling ResetStackTrace");
                ResetStackTrace();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            Console.ReadKey(true);
        }

        private static void KeepStackTrace()
        {
            Layer2 l2 = new Layer2();
            try
            {
                l2.Layer2Method();
            }
            catch (InvalidOperationException)
            {
                throw;
            }
        }

        private static void ResetStackTrace()
        {
            Layer2 l2 = new Layer2();
            try
            {
                l2.Layer2Method();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;               //csak innentől kezdve marad meg a stacktrace-ben
            }
        }
    }
}
