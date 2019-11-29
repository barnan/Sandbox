using System;
using System.Xml.Serialization;

namespace proj2
{
    [XmlRoot("Project")]
    public class Project
    {
        [XmlAttribute("Prop1")]
        public int Prop1 { get; set; }

        [XmlAttribute("Prop2")]
        public string Prop2 { get; set; }

        [XmlElement("Prop3")]
        public int Prop3 { get; set; }

        [XmlElement("Prop4")]
        public string Prop4 { get; set; }
    }



    public class Projectecske1
    {

        public Projectecske1(Projectecske2 proj2)
        {
            proj2.Handlerecske += func1;
            proj2.Handlerecske += func2;
        }

        private void func2(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void func1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


    }




    public class Projectecske2
    {
        public event EventHandler Handlerecske;


        public void Do()
        {
            try
            {
                Handlerecske(this, new EventArgs());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


    }



    public class Project2
    {
        private int _prop1;
        public int Prop1
        {
            get => _prop1;
            set => _prop1 = value;
        }

        public override int GetHashCode()
        {
            return _prop1.GetHashCode();
        }


        public static bool operator ==(Project2 op1, Project2 op2)
        {
            if (object.Equals(op1, null) && object.Equals(op2, null))
                return true;

            return !object.Equals(op1, null) && !object.Equals(op2, null) && op1.Prop1 == op2.Prop1;
        }

        public static bool operator !=(Project2 op1, Project2 op2)
        {
            return !(op1 == op2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is Project2))
                return false;

            return this == (Project2)obj;
        }

        public static bool operator <(Project2 op1, Project2 op2)
        {
            return op1.Prop1 < op2.Prop1;
        }

        public static bool operator >(Project2 op1, Project2 op2)
        {
            return op1.Prop1 > op2.Prop1;
        }

        public static bool operator <=(Project2 op1, Project2 op2)
        {
            return op1 < op2 || op1 == op2;
        }

        public static bool operator >=(Project2 op1, Project2 op2)
        {
            return op1 > op2 || op1 == op2;
        }

        public int Compare(Project2 x, Project2 y)
        {
            return x < y ? -1 : 1;
        }

    }


}
