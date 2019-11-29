using System;

namespace PropInfo
{
    public class ExampleClass1
    {
        public int Prop1 { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {

            string strvariable = string.Empty;

            switch (strvariable)
            {
                case "valami":
                    break;
                case "":
                    break;
                default:
                    break;
            }




            Type type1 = typeof(ExampleClass1);
            var variable = type1.GetProperties();


        }
    }
}
