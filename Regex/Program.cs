using System;
using System.Text.RegularExpressions;


[assembly: CLSCompliant(true)]



namespace RegexPelda
{
    class Program
    {
        public static UInt32 Valami { get; set; }

        static void Main(string[] args)
        {
        //    string text = "valami 30000";
        //    string text1 = "valami 300.01";
        //    string text2 = "valami 300";


        //    Match mat = Regex.Match(text, @"\d+");
        //    string[] content = Regex.Split(text, "[^\\d]");
        //    string resu = string.Join(null, content);


        //    Match mat2 = Regex.Match(text1, @"[0-9]*\.?[0-9]+");
        //    string[] contentfloat = Regex.Split(text1, "[^\\d.]");
        //    string resufloat = string.Join(null, contentfloat);


        //    Match mat3 = Regex.Match(text2, @"[0-9]*\.?[0-9]+");
        //    string[] contentfloat2 = Regex.Split(text2, "[^\\d.]");
        //    string resufloat2 = string.Join(null, contentfloat2);



            string pattern = @"\[A, '[^\[\]]*'\]";
            Regex rgx = new Regex(pattern);
            string sentence = "Device Reply To Host S7F20 W0 Body [L, [A, 'MEASUREMENT/222222222;1'], [A, 'MEASUREMENT/M100x_1300LP_regular;1']]";

            foreach (Match match in rgx.Matches(sentence))
                Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index);

            Console.ReadKey();
        }
    }
}
