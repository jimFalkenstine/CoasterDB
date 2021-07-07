using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoasterDB
{
    public class WorldCoasterComparer : IComparer<WorldCoaster>
    {
        public int Compare(WorldCoaster x, WorldCoaster y)
        {
            return x.Height.CompareTo(y.Height) * -1;
        }
    }
}
