using System;

namespace DateTimeFormats
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime datetime = DateTime.Now;
            DateTime datetime2 = DateTime.Parse("2019.03.06. 9:7:2");

            Console.WriteLine(datetime.ToString("yyMMddhh"));
            Console.WriteLine(datetime2.ToString("yyMMddhh"));

            char month = Converter(DateTime.Now.Month);
            char day = Converter(DateTime.Now.Day);


            Console.ReadKey();
        }



        private static char Converter(int number)
        {
            if (number < 10)
            {
                return number.ToString()[0];
            }
            else
            {
                return (char)((int)'A' + number - 10);
            }
        }


    }
}
