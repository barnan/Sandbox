using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using WpfApp1;

namespace proj2
{

    public enum NorbiEnum
    {
        Barna,
        Norbert
    }


    public static class Extensions
    {
        public static IEnumerable<T> GetDuplicatedElements<T>(this List<T> source, IEqualityComparer<T> comparer = null)
        {
            if (source == null)
            {
                return new List<T>();
            }

            ICollection<T> uniqueElements = new Collection<T>();
            ICollection<T> duplicatedElements = new Collection<T>();

            foreach (var item in uniqueElements)
            {
                ;
            }

            foreach (var item in source)
            {
                if (!uniqueElements.Contains(item, comparer))
                {
                    uniqueElements.Add(item);
                }
                else
                {
                    duplicatedElements.Add(item);
                }
            }

            return duplicatedElements;
        }


        public static bool CheckAvailableList<T>(this List<T> input, string name, IComparer<T> comparer = null)
        {
            if (input.Count == 0)
            {
                return false;
            }

            IEnumerable<T> duplicatedElements = input.GetDuplicatedElements();
            foreach (var element in duplicatedElements)
            {
                input.Remove(element);
            }

            input.Sort(comparer);

            return true;
        }


        public static List<T> GetDuplicatedElements_Linq<T>(this List<T> source)
        {
            var query = source.GroupBy(x => x)
                .Where(g => g.Count() > 1);

            var result_query = query.Select(y => y.Key).ToList();

            return result_query;
        }
    }



    class Equality : IEqualityComparer<Project2>
    {
        public bool Equals(Project2 x, Project2 y)
        {
            return x == y;
        }

        public int GetHashCode(Project2 obj)
        {
            return obj.GetHashCode();
        }
    }
    

    class Program
    {


        private static ManualResetEvent _finishedEvent;

        static void Main(string[] args)
        {


            List<string> szoveg = new List<string>();
            szoveg.Add(null);



            List<Project2> lista = new List<Project2> { new Project2 { Prop1 = 10 }, new Project2 { Prop1 = 20 }, new Project2 { Prop1 = 10 }, new Project2 { Prop1 = 30 }, new Project2 { Prop1 = 40 }, new Project2 { Prop1 = 40 } };
            List<double> lista1 = new List<double> { 4.45555555555555, 5.5, 4.45555555555555, 1.1, 2.2, };

            //var list2 = lista.GetDuplicatedElements();
            var lista3 = lista.Distinct(EqualityComparer<Project2>.Default);

            bool success = lista.CheckAvailableList(nameof(lista1));




            Projectecske2 proj2 = new Projectecske2();
            Projectecske1 proj1 = new Projectecske1(proj2);

            proj2.Do();





            NorbiEnum nenum1 = NorbiEnum.Barna;
            //NorbiEnum nenum2 = Enum.Parse(typeof(NorbiEnum), 2);
            var res = Enum.IsDefined(typeof(NorbiEnum), (NorbiEnum)1);
            NorbiEnum nenum3 = (NorbiEnum)4;


            Console.WriteLine(nenum1);
            Console.WriteLine(res);
            Console.WriteLine(nenum3);




            _finishedEvent = new ManualResetEvent(false);

            var theApp = new Thread(() =>
            {
                var app = new System.Windows.Application();


                MainWindow mainWindow = new MainWindow();
                mainWindow.Title = "Something";
                mainWindow.Closed += WpfClosed;
                mainWindow.Show();

                //System.Windows.Application.Current.MainWindow = mainWindow;
                //mainWindow.Show();
                app.Run(mainWindow);

            });
            Debug.Assert(theApp != null);
            theApp.Name = "WpfThread";
            theApp.IsBackground = true;
            theApp.SetApartmentState(ApartmentState.STA);
            theApp.Start();






            //Application appl = new App();
            //appl.Run(new MainWindow());


            BitArray ba1 = new BitArray(8);
            BitArray ba2 = new BitArray(8);

            byte[] a = { 60 };
            byte[] b = { 13 };

            //storing the values 60, and 13 into the bit arrays
            ba1 = new BitArray(600);
            ba2 = new BitArray(b);



            //content of ba1
            Console.WriteLine("Bit array ba1: 60");

            for (int i = 0; i < ba1.Count; i++)
            {
                Console.Write("{0, -6} ", ba1[i]);
            }
            Console.WriteLine();

            //content of ba2
            Console.WriteLine("Bit array ba2: 13");
            for (int i = 0; i < ba2.Count; i++)
            {
                Console.Write("{0, -6} ", ba2[i]);
            }
            Console.WriteLine();



            List<Project> proj = new List<Project>{ new Project{Prop1 = 1, Prop2 = "ketto", Prop3 = 3, Prop4 = "négy"},
                                                    new Project { Prop1 = 11, Prop2 = "tizenketto", Prop3 = 13, Prop4 = "tizennégy" } };


            string tempStr = SerializeObject<List<Project>>(proj);
            List<Project> tempProjects = DeserializeObject<List<Project>>(tempStr);



            XDocument srcTree = new XDocument(
                new XComment("This is a comment"),
                new XElement("Root",
                    new XElement("Child1", "data1"),
                    new XElement("Child2", "data2"),
                    new XComment("This is a comment 2"),
                    new XElement("Child3", "data3"),
                    new XElement("Child2", "data4"),
                    new XElement("Info5", "info5"),
                    new XElement("Info6", "info6"),
                    new XElement("Info7", "info7"),
                    new XElement("Info8", "info8")

                )
            );

            XDocument doc = new XDocument(
                new XComment("This is a comment"),
                new XElement("Root",
                    from el in srcTree.Element("Root").Elements()
                    where ((string)el).StartsWith("data")
                    select el
                )
            );


            _finishedEvent.WaitOne();


            //Console.ReadKey();
        }

        private static void WpfClosed(object sender, EventArgs e)
        {
            _finishedEvent.Set();
        }


        public static T DeserializeObject<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var tr = new StringReader(xml))
            {
                return (T)serializer.Deserialize(tr);
            }
        }

        public static string SerializeObject<T>(T obj)
        {
            var serializer = new XmlSerializer(typeof(T));

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new UnicodeEncoding(true, true);
            settings.Indent = true;
            settings.OmitXmlDeclaration = false;

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("egyik", "masik");

            using (StringWriter textWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    serializer.Serialize(xmlWriter, obj, ns);
                }

                return textWriter.ToString(); //This is the output as a string  
            }
        }
    }
}
