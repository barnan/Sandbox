using System;

namespace Investigate_NumericData_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"byte {sizeof(byte)}");
            Console.WriteLine($"sbyte {sizeof(sbyte)}");
            Console.WriteLine($"char {sizeof(char)}");
            Console.WriteLine($"short {sizeof(short)}");
            Console.WriteLine($"ushort {sizeof(ushort)}");


            Console.ReadKey();
        }
    }
}
