using System;

namespace Investigate_NumericData_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"bool {sizeof(bool)}");
            Console.WriteLine($"byte {sizeof(byte)}");
            Console.WriteLine($"sbyte {sizeof(sbyte)}");
            Console.WriteLine($"char {sizeof(char)}");
            Console.WriteLine($"short {sizeof(short)}");
            Console.WriteLine($"ushort {sizeof(ushort)}");
            Console.WriteLine($"Int16 {sizeof(Int16)}");
            Console.WriteLine($"Int32 {sizeof(Int32)}");
            Console.WriteLine($"int {sizeof(int)}");
            Console.WriteLine($"Int64 {sizeof(Int64)}");
            Console.WriteLine($"UInt64 {sizeof(UInt64)}");
            Console.WriteLine($"long {sizeof(long)}");
            Console.WriteLine($"float {sizeof(float)}");
            Console.WriteLine($"double {sizeof(double)}");
            Console.WriteLine($"decimal {sizeof(decimal)}");

            Console.ReadKey();
        }
    }
}
