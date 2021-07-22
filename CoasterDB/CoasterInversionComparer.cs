using System.Collections.Generic;

namespace CoasterDB
{
    class CoasterInversionComparer : IComparer<Coaster>
    {
        public int Compare(Coaster x, Coaster y)
        {
            return x.Inversions.CompareTo(y.Inversions) * -1;
        }
    }
}
