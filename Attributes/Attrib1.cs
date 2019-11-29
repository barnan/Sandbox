using System;
using System.CodeDom;

namespace Attributes
{

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    class Custom01Attribute : Attribute
    {
        public Custom01Attribute(string message1)
        {
            Message1 = message1;
        }

        internal string Message1 { get; }

        public string Message2 { get; set; }
    }




    //[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false)]
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    class Custom02Attribute : Attribute
    {
        public Custom02Attribute(string message1)
        {
            Message1 = message1;
        }

        internal string Message1 { get; }

        public string Message2 { get; set; }
    }



    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class DeBugInfoAttribute : Attribute
    {
        private int bugNo;
        private string developer;
        private string lastReview;
        public string message;

        public DeBugInfoAttribute(int bg, string dev, string d)
        {
            this.bugNo = bg;
            this.developer = dev;
            this.lastReview = d;
        }
        public int BugNo
        {
            get
            {
                return bugNo;
            }
        }
        public string Developer
        {
            get
            {
                return developer;
            }
        }
        public string LastReview
        {
            get
            {
                return lastReview;
            }
        }
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }
    }



    [DeBugInfo(201, "BarnaNorbika", "tegnap")]
    [DeBugInfo(200, "BarnaNorbika", "tegnapelőtt")]
    [Custom01("saját", Message2 = "saját2")]
    [Custom02("saját", Message2 = "saját2")]
    // [Custom01("saját2", Message2 = "saját2")]   -> ebből az attribútumból csak egy lehet rajta
    class MyBaseClass
    {

        public int IntProperty { get; set; }

    }



    [CLSCompliant(true)]
    class MyDerivedClass : MyBaseClass
    {

        [DeBugInfo(202, "BarnaNorbika", "ma")]
        public void DoSomething()
        {
        }


        public uint m = 0;



        public double DoubleProperty { get; set; }

    }

}
