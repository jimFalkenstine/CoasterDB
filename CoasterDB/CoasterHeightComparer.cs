using System.Collections.Generic;


namespace CoasterDB
{
    public class CoasterHeightComparer : IComparer<Coaster>
    {
        public int Compare(Coaster x, Coaster y)
        {
            return x.Height.CompareTo(y.Height) * -1;
        }
    }
}
