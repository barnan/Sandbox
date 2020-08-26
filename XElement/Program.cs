using System;
using System.Linq;
using System.Xml.Linq;

namespace XElementProj
{
    class Program
    {

        static XElement CreateXElement()
        {
            XElement elementChild = new XElement("Cat");
            elementChild.Add(new XAttribute("Name", "Mici"));
            elementChild.Add(new XAttribute("Color", "Black"));

            XElement element = new XElement("Cats");
            element.Add(elementChild);

            XDocument xDoc = new XDocument();
            xDoc.Add();

            xDoc.Save("MiciCica.xml");



            XElement element4 = new XElement("Level4", 50);
            XElement element3 = new XElement("Level3");
            element3.Add(element4);
            element3.Add(new XAttribute(name: "Level3_Attrib_Name", value: "Level3_Attrib_Value"));

            XElement element21 = new XElement("Level2");
            element21.Add(element3);
            element21.Add(new XAttribute(name: "Level2_Attrib_Name", value: 100));

            XElement element22 = new XElement("Level2");
            element22.Add(element3);
            element22.Add(new XAttribute(name: "Level2_Attrib_Name", value: 200));

            XElement element23 = new XElement("Level2");
            element23.Add(element3);
            element23.Add(new XAttribute(name: "Level2_Attrib_Name", value: 300));

            XElement element1 = new XElement("Level1");
            element1.Add(element21);
            element1.Add(element22);
            element1.Add(element23);


            return element1;
        }



        static void Main(string[] args)
        {

            XElement element = CreateXElement();

            XElement[] levels = element.Elements("Level02").ToArray();


            Console.ReadKey();
        }
    }
}
