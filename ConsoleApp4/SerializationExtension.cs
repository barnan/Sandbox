using System;
using System.Collections;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ConsoleApp4
{
    public static class SerializationExtension
    {

        public static void TrySave<T>(T inputobj, XElement element, bool saveAttributes)
        {
            if (Equals(inputobj, null))
            {
                return;
            }

            Type inputType = typeof(T);
            if (inputType == typeof(object))
            {
                inputType = inputobj.GetType();
            }

            IList listVersion = inputobj as IList;
            IDictionary dictVersion = inputobj as IDictionary;
            IXmlStorable xmlstorableVerison = inputobj as IXmlStorable;
            ISerializable serialiableVersion = inputobj as ISerializable;

        }



        public static void TrySave<T>(this IXmlStorable storable, T inputobj, XElement element, bool saveAttributes)
        {

        }

    }
}
