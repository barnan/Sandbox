using System;
using System.Linq;
using System.Xml.Linq;

namespace ConsoleApp2
{
    public class UPCDLineScan : IuPCDLineScan
    {
        private string _TIMELIFETIME_XELEMENT_NAME = "TimeLifetime";
        private string _UPCDPOINT_XELEMENT_NAME = "SingleUpcdMeas";
        private string _TIME_XELEMENT_NAME = "Time";
        private string _LIFETIME_XELEMENT_NAME = "Lifetime_us";

        #region Implementation of IuPCDLineScan

        public DateTime DateTime { get; set; }

        public IuPCDPoint[] TimeLifetime { get; set; }

        public string ToolId { get; set; }

        public string WaferId { get; set; }

        #endregion

        #region Implementation of IXmlStoreable

        public void LoadFromXml(XElement element)
        {
            XElement dateTimeElement = element.Element(nameof(DateTime));
            XElement toolIdElement = element.Element(nameof(ToolId));
            XElement waferIdElement = element.Element(nameof(WaferId));

            if (dateTimeElement != null)
            {
                DateTime = DateTime.Parse(dateTimeElement.Value);
            }

            if (toolIdElement != null)
            {
                ToolId = toolIdElement.Value;
            }

            if (waferIdElement != null)
            {
                WaferId = waferIdElement.Value;
            }


            XElement timeLifeTimeXElement = element?.Element(_TIMELIFETIME_XELEMENT_NAME);
            XElement[] singleUpcdMeasElements = timeLifeTimeXElement?.Elements(_UPCDPOINT_XELEMENT_NAME).ToArray();

            TimeLifetime = new IuPCDPoint[singleUpcdMeasElements.Length];

            for (int i = 0; i < singleUpcdMeasElements.Length; i++)
            {
                double time;
                double lifetime;

                if (double.TryParse(Convert.ToString(singleUpcdMeasElements[i]?.Element(_TIME_XELEMENT_NAME)), out time) && double.TryParse(Convert.ToString(singleUpcdMeasElements[i]?.Element(_LIFETIME_XELEMENT_NAME)), out lifetime))
                {
                    TimeLifetime[i] = new UpcdPoint
                    {
                        Time = time,
                        Lifetime_us = lifetime
                    };
                }
            }
        }

        public XElement SaveToXml(XElement element)
        {
            XElement dataTimeElement = new XElement(nameof(DateTime), DateTime);
            XElement toolIdElement = new XElement(nameof(ToolId), ToolId);
            XElement waferIdElement = new XElement(nameof(WaferId), WaferId);

            XElement timeLifeTimeXElement = new XElement(_TIMELIFETIME_XELEMENT_NAME);
            foreach (IuPCDPoint item in TimeLifetime)
            {
                XElement upcdPoint = new XElement(_UPCDPOINT_XELEMENT_NAME);
                XElement timeXElement = new XElement(_TIME_XELEMENT_NAME, item.Time);
                XElement lifetimeXElement = new XElement(_LIFETIME_XELEMENT_NAME, item.Lifetime_us);

                upcdPoint.Add(timeXElement);
                upcdPoint.Add(lifetimeXElement);

                timeLifeTimeXElement.Add(upcdPoint);
            }
            element.Add(timeLifeTimeXElement);
            return element;
        }

        #endregion
    }


    public class UpcdPoint : IuPCDPoint
    {
        #region Implementation of IuPCDPoint

        public double Time { get; set; }

        public double Lifetime_us { get; set; }

        #endregion
    }


    public interface IuPCDLineScan
    {
        DateTime DateTime { get; }

        IuPCDPoint[] TimeLifetime { get; }

        string ToolId { get; set; }

        string WaferId { get; set; }
    }

    public interface IuPCDPoint
    {
        double Time { get; }

        double Lifetime_us { get; }
    }

}
