using System.Collections.Generic;


namespace CoasterDB
{
    class CoasterLengthComparer : IComparer<Coaster>
    {
        public int Compare(Coaster x, Coaster y)
        {
            return x.Length.CompareTo(y.Length) * -1;
        }
    }
}
