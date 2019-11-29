using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml.Linq;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = @"d:\_SW_Projects\InlineTeam\Inline-Sandbox\MSA_Evaluator\Trunk\Src\PC\MSA_Evaluator\Config\SpecificationFiles\PLI";

            Console.WriteLine(Path.GetFileName(path));

            //XDocument doc;
            //using (TextReader tr = new StreamReader(@"c: \Users\norbert.barna\Source\Repos\MeasurementEvaluator\bin\Debug\Configuration\MeasurementEvaluator.config"))
            //{
            //    doc = XDocument.Load(tr);
            //}

            XElement root = new XElement("root");
            ValidIfRelations rel = ValidIfRelations.ALLWAYS;
            root.Add(new XElement("ValidIf", rel));
            var rel2 = (ValidIfRelations)root.Element("ValidIf").Value;


            XElement root20 = new XElement("root20");
            Relations rel20 = Relations.GREATER;

            root20.Add(new XElement("Rel", rel20));

            var rel21 = (Relations)root20.Element("Rel").Value;


            string valalmi = Path.Combine("C:\\Mucika", "kismokus.txt");


            Ember[] emberList = new Ember[2];
            emberList[0] = new Ember("Rick", 150, "Chicago", new List<Auto> { new Auto(AutoType.Cabrio, Color.Azure, "Opel") });
            emberList[1] = new Ember("Dave", 160, "Missouri", new List<Auto> { new Auto(AutoType.Limusin, Color.Bisque, "Citroen") });

            //foreach (Ember ember in emberList)
            //{
            //    Console.WriteLine(ember.Name);
            //}
            //Console.WriteLine(Environment.NewLine);

            Ember[] emberList2 = (Ember[])emberList.Clone();
            emberList[1] = new Ember("Redjohn", 130, "New York", new List<Auto> { new Auto(AutoType.SUV, Color.DarkBlue, "Peugeot") });

            //foreach (Ember ember in emberList)
            //{
            //    Console.WriteLine(ember.Name);
            //}
            //Console.WriteLine(Environment.NewLine);
            //foreach (Ember ember in emberList2)
            //{
            //    Console.WriteLine(ember.Name);
            //}
            //Console.WriteLine(Environment.NewLine);


            XElement rootElement = new XElement("Root");
            foreach (Ember ember in emberList)
            {
                ember.SaveToXml(rootElement);
            }





            Console.ReadKey();


        }
    }



    public class Relations : ValidIfRelations
    {


        public Relations(string name, int value)
            : base(name, value)
        {

        }

        public class RelationsEnumValues : ValidIfRelationsEnumValues
        {
            public const int EQUAL = 0;
            public const int NOTEQUAL = 1;
            public const int LESS = 2;
            public const int LESSOREQUAL = 3;
            public const int GREATER = 4;
            public const int GREATEROREQUAL = 5;
        }

        public static Relations EQUAL = new Relations(nameof(EQUAL), RelationsEnumValues.EQUAL);
        public static Relations NOTEQUAL = new Relations(nameof(NOTEQUAL), RelationsEnumValues.NOTEQUAL);
        public static Relations LESS = new Relations(nameof(LESS), RelationsEnumValues.LESS);
        public static Relations LESSOREQUAL = new Relations(nameof(LESSOREQUAL), RelationsEnumValues.LESSOREQUAL);
        public static Relations GREATER = new Relations(nameof(GREATER), RelationsEnumValues.GREATER);
        public static Relations GREATEROREQUAL = new Relations(nameof(GREATEROREQUAL), RelationsEnumValues.GREATEROREQUAL);

        public override string ToString()
        {
            return Name;
        }

        public static implicit operator int(Relations rel)
        {
            return rel.Value;
        }


        public static explicit operator Relations(string val)
        {

            if (EQUAL.ToString() == val)
            {
                return EQUAL;
            }
            if (NOTEQUAL.ToString() == val)
            {
                return NOTEQUAL;
            }
            if (LESS.ToString() == val)
            {
                return LESS;
            }
            if (LESSOREQUAL.ToString() == val)
            {
                return LESSOREQUAL;
            }
            if (GREATER.ToString() == val)
            {
                return GREATER;
            }
            if (GREATEROREQUAL.ToString() == val)
            {
                return GREATEROREQUAL;
            }

            return null;
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object other)
        {
            Relations otherRelation = other as Relations;
            if (ReferenceEquals(null, otherRelation))
            {
                return false;
            }
            return Value == otherRelation.Value;
        }

    }



    public class ValidIfRelations
    {
        public string Name { get; }
        public int Value { get; }

        public ValidIfRelations(string name, int value)
        {
            Name = name;
            Value = value;

        }

        public class ValidIfRelationsEnumValues
        {
            public const int ALLWAYS = 6;
        }

        public static ValidIfRelations ALLWAYS = new ValidIfRelations(nameof(ALLWAYS), ValidIfRelationsEnumValues.ALLWAYS);

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object other)
        {
            return base.Equals(other);
        }
        public static explicit operator ValidIfRelations(string val)
        {
            if (ALLWAYS.ToString() == val)
            {
                return (ValidIfRelations)ALLWAYS;
            }

            return null;
        }
    }


}
