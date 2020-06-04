using System;
using System.ComponentModel;

namespace Enums
{

    class Program
    {

        static void Main(string[] args)
        {
            Ember ember = new Ember();
            ember.DoSomething();

            string text = "00000011";

            ErrorValues errorValue = (ErrorValues)Convert.ToInt32(text, 2);

            int szam = 21;
            ValamiEnnum valenum = (ValamiEnnum)szam;

            Func(valenum);

            if (valenum > ValamiEnnum.masik)
            {
                Console.WriteLine("Nagyobb, mint masik");
            }

            Console.ReadKey();
        }


        // enumként jön be, de nemcsak az enumban felvehető értékeket veheti fel, ezért ellenőrizni kell rá!!!!!!!!
        public static void Func(ValamiEnnum input)
        {
            if (!Enum.IsDefined(typeof(ValamiEnnum), input))
            {

                var elements = Enum.GetValues(typeof(ValamiEnnum));
                //throw new ArgumentException("Not part of the value set.");
                Console.WriteLine($"Not part of the enum elements: {input}. possible values: {string.Join(",", elements)}");
            }
            else
            {
                Console.WriteLine(input);
            }

        }
    }


    public enum ValamiEnnum
    {
        egyik = 0,

        masik = 1,

        harmadik = 2
    }


    [Flags]
    public enum ErrorValues
    {
        [Description("No error.")]
        None = 0,

        [Description("Command not recognized.")]
        CMD_NOT_RECOGNIZED = 1,

        [Description("Parameter out of range.")]
        PARAM_OUT_OF_RANGE = 2,

        [Description("Trigger too soon.")]
        TRIG_TOO_SOON = 4,

        [Description("Trigger minimum low violation.")]
        TRIG_MIN_LOW_VIOLATION = 8,

        [Description("Trigger minimum high violation.")]
        TRIG_MIN_HIGH_VIOLATION = 16,

        [Description("Trigger minimum period violation.")]
        TRIG_MIN_PERIOD_VIOLATION = 32,
    }

}
