using System.Drawing;

namespace ConsoleApp4
{
    public class Auto
    {
        public AutoType AutoType { get; set; }
        public Color Color { get; set; }
        public string Vendor { get; set; }

        public Auto(AutoType autoType, Color color, string vendor)
        {
            AutoType = autoType;
            Color = color;
            Vendor = vendor;
        }
        public Auto()
        {
        }
    }




    public enum AutoType : byte
    {
        Unknown = 0,
        Cabrio,
        Buggy,
        SUV,
        Limusin
    }
}
