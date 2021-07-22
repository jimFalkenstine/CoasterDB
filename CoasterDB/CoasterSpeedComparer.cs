using System.Collections.Generic;

namespace CoasterDB
{
    class CoasterSpeedComparer : IComparer<Coaster>
    {
        public int Compare(Coaster x, Coaster y)
        {
            return x.Speed.CompareTo(y.Speed) * -1;
        }
    }
}
