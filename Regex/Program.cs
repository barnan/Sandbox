using System;
using System.Text.RegularExpressions;

[assembly: CLSCompliant(true)]

namespace RegexPelda
{
    internal class Program
    {
        public static UInt32 Valami { get; set; }

        private static void Main(string[] args)
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

            #region 1

            string pattern = @"\[A, '[^\[\]]*'\]";
            Regex rgx = new Regex(pattern);
            string sentence = "Device Reply To Host S7F20 W0 Body [L, [A, 'MEASUREMENT/222222222;1'], [A, 'MEASUREMENT/M100x_1300LP_regular;1']]";

            foreach (Match match in rgx.Matches(sentence))
                Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index);

            #endregion 1

            Console.WriteLine(Environment.NewLine);

            #region 2

            string pattern2 = @"\[U4, [\d^\[\]]+L\]";
            string pattern3 = @" [\d]+";
            //string pattern3 =
            Regex rgx2 = new Regex(pattern2);
            Regex rgx3 = new Regex(pattern3);
            string sentence2 = "Device Message To Host S6F11 W1 Body [L, [U4, 106L], [U4, 1001L], [L, [L, [U4, 1179L], [L, [A, 'Carrier1'], [A, ''], [A, '24'], [A, 'Carrier1_24'], [A, '13/01/2021 09:33:45'], [A, '00:00:07.3207604'], [A, 'Completed'], [F8, 1.0], [F8, 1.0], [F8, 1.0], [F8, 0.0], [F8, 37.09220240815438], [F8, 37.09220240815438], [F8, 37.09220240815438], [F8, 0.0], [F8, NaN], [F8, NaN], [F8], [F8], [F8], [F8]]]]]";

            foreach (Match match2 in rgx2.Matches(sentence2))
            {
                Console.WriteLine("Found '{0}' at position {1}", match2.Value, match2.Index);

                foreach (Match match3 in rgx3.Matches(match2.ToString()))
                {
                    Console.WriteLine("Found '{0}' at position {1}", match3.Value, match3.Index);
                }
            }

            #endregion 2

            Console.ReadKey();
        }
    }
}