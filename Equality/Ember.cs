using System;

namespace Equality
{
    public class Ember : IEquatable<Ember>, IComparable, IComparable<Ember>
    {
        public string Name { get; set; }


        //ha ember típusúra hívjuk meg az Equals()-t, IEquatable része. Az IEquatable-t a listák, dictionary-k használják
        public bool Equals(Ember other)
        {
            return Name == other.Name;
        }

        // ha object típusúra hívjuk meg az Equals()-t
        public override bool Equals(object other)
        {
            if (!(other is Ember emberObj))
            {
                return false;
            }
            return Name == emberObj.Name;
        }

        public int CompareTo(object obj)
        {
            Ember emberObj = obj as Ember;
            return Name.CompareTo(emberObj.Name);
        }

        public int CompareTo(Ember ember)
        {
            return Name.CompareTo(ember.Name);
        }


        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
