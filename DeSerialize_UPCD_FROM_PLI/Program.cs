using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace DeSerialize_UPCD_FROM_PLI
{
    class Program
    {









        static void Main(string[] args)
        {
            string name = "UPCD_NEW2";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load($"{name}.xml");

            List<UPCD_Point> lista = new List<UPCD_Point>();

            XmlNodeList nodeList = xmlDoc.SelectNodes("//UPCDLineScan/TimeLifetime/SingleUpcdMeas");

            foreach (var singleUpcdMeas in nodeList)
            {
                string strTime = ((XmlNode)singleUpcdMeas).FirstChild.InnerText;
                string strLifeTime_us = ((XmlNode)singleUpcdMeas).LastChild.InnerText;

                double time;
                double lifetime;

                double.TryParse(strTime, out time);
                double.TryParse(strLifeTime_us, out lifetime);


                lista.Add(new UPCD_Point { Time = time, LifeTime_us = lifetime });
            }


            using (StreamWriter sw = new StreamWriter($"{name}.csv"))
            {
                foreach (UPCD_Point point in lista)

                {
                    sw.WriteLine($"{point.Time},{point.LifeTime_us}");
                }
            }


        }
    }
}
