using System.Collections.Generic;

namespace Equality
{
    class EmberEquality : IEqualityComparer<Ember>
    {
        public bool Equals(Ember x, Ember y)
        {
            return x.Equals(y);
        }

        public int GetHashCode(Ember obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}
