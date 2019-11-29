namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {

            LineFit lf = new LineFit { End1Row = 100, End2Row = 200, End1Column = 100, End2Column = 100, R2 = 1.3 };
            SerializableLineFit slf = new SerializableLineFit(lf);





        }
    }
}
