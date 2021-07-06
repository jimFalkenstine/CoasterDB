using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoasterDB
{
    public class Coaster 
    {
        public string Name { get; set; }
        public string Park { get; set; }
        public string Type { get; set; }
        public string Design { get; set; }
        public string Make { get; set; }
        public double Length { get; set; }
        public double Height { get; set; }
        public double Speed { get; set; }
        public int Inversions { get; set; }
        public int Year { get; set; }
        public Active Active { get; set; }
        //public string[] OtherNames { get; set; }
    }

    public enum Active
    {
        Active,
        Defunct
    }
}
