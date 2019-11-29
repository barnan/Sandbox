using System.Collections.Generic;

namespace Equality
{
    class EmberComparer : IComparer<Ember>
    {
        public int Compare(Ember x, Ember y)
        {
            return x.CompareTo(y);
        }
    }
}
