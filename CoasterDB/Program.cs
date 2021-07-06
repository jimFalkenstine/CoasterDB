using System;
using System.Collections.Generic;
using System.IO;

namespace CoasterDB
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "CoasterCount-ActiveCoasters.csv");
            var fileContents = ReadCoasterCount(fileName);
        }

        public static string ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName)) 
            {
                return reader.ReadToEnd();
            }
        }

        public static List<Coaster> ReadCoasterCount(string fileName) 
        {
            var coasterCount = new List<Coaster>();
            using (var reader = new StreamReader(fileName)) 
            {
                string line = "";
                reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    var coaster = new Coaster();
                    string[] values = line.Split(',');
                    coaster.Name = values[0];
                    coaster.Park = values[1];
                    coaster.Type = values[2];
                    coaster.Design = values[3];
                    coaster.Make = values[4];
                    double parseDouble;
                    if (double.TryParse(values[5], out parseDouble)) 
                    {
                        coaster.Length = parseDouble;  
                    }
                    if (double.TryParse(values[6], out parseDouble))
                    {
                        coaster.Height = parseDouble;
                    }
                    if (double.TryParse(values[7], out parseDouble))
                    {
                        coaster.Speed = parseDouble;
                    }
                    int parseInt;
                    if (int.TryParse(values[8], out parseInt)) 
                    {
                        coaster.Inversions = parseInt;
                    }
                    if (int.TryParse(values[9], out parseInt))
                    {
                        coaster.Year = parseInt;
                    }
                    Active active;
                    if (Enum.TryParse(values[10], out active))
                    {
                        coaster.Active = active;
                    }
                    //coaster.OtherNames = values[11];
                    coasterCount.Add(coaster);

                }
            }
            return coasterCount;
        }
    }
}
