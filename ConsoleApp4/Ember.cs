using System.Collections.Generic;
using System.Xml.Linq;

namespace ConsoleApp4
{
    public class Ember : IXmlStorable
    {
        public string Name { get; set; }

        public int Height { get; set; }

        //[Configuration("Address of the Ember")]
        public string Address { get; set; }

        public List<Auto> Auto { get; set; }


        public Ember()
        {

        }

        public Ember(string name, int height, string address, List<Auto> auto)
        {
            Name = name;
            Height = height;
            Address = address;
            Auto = auto;
        }


        public XElement SaveToXml(XElement inputElement)
        {
            inputElement.Add(new XElement(nameof(Name), Name));
            inputElement.Add(new XElement(nameof(Height), Height));
            inputElement.Add(new XElement(nameof(Address), Address));
            inputElement.Add(new XElement(nameof(Auto), Auto));
            return inputElement;
        }

        public bool LoadFromXml(XElement inputElement)
        {
            Name = inputElement.Element(nameof(Name)).Value;
            Height = int.Parse(inputElement.Element(nameof(Height)).Value);
            Address = inputElement.Element(nameof(Address)).Value;
            //Auto = inputElement.Element(nameof(Auto)).Value;
            return true;
        }
    }
}
