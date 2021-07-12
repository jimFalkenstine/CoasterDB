using System.Collections.Generic;


namespace CoasterDB
{
    public class MyCoasterComparer : IComparer<MyCoaster>
    {
        public int Compare(MyCoaster x, MyCoaster y)
        {
            return x.Height.CompareTo(y.Height) * -1;
        }
    }
}
