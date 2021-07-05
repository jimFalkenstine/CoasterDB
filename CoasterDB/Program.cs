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

        public static List<string[]> ReadCoasterCount(string fileName) 
        {
            var coasterCount = new List<string[]>();
            using (var reader = new StreamReader(fileName)) 
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(',');
                    coasterCount.Add(values);

                }
            }
            return coasterCount;
        }
    }
}
