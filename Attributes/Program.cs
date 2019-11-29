using System;
using System.Collections.Generic;
using System.Reflection;

namespace Attributes
{
    class Program
    {

        static void Main(string[] args)
        {
            // -------------------- base class ---------------------------------------------------------------

            MemberInfo basememinfo = typeof(MyBaseClass);
            IEnumerable<Attribute> basedebugAttributes = basememinfo.GetCustomAttributes<DeBugInfoAttribute>();
            IEnumerable<Attribute> basecustomAttributes = basememinfo.GetCustomAttributes();

            // -------------------- derived class---------------------------------------------------------------

            MemberInfo derivedmeminfo = typeof(MyDerivedClass);
            IEnumerable<Attribute> deriveddebugAttributes = derivedmeminfo.GetCustomAttributes<DeBugInfoAttribute>();
            IEnumerable<Attribute> derivedcustomAttributes = derivedmeminfo.GetCustomAttributes();


            // -------------------- Propety info -ból ---------------------------------------------------------------


            PropertyInfo[] propInfos = typeof(MyDerivedClass).GetProperties();

            MethodInfo[] methodInfos = typeof(MyDerivedClass).GetMethods();


            foreach (Attribute attribute in methodInfos[0].GetCustomAttributes())
            {
                Console.WriteLine(((DeBugInfoAttribute)attribute).BugNo);
            }

            Console.ReadKey();
        }
    }
}
