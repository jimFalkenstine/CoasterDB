using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
