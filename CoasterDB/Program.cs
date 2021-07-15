using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace CoasterDB
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "coasters.json");
            var coasters = DeserializeCoasters(fileName);

            var kICoasters = from c in coasters
                               where c.Park == "Kings Island"
                               select c;

            var removedCoasters = from c in coasters
                                    where c.Status == "Removed"
                                    select c;

            var coastersByPark = from c in coasters
                                   group c by c.Park;

            var coastersByYear = from c in coasters
                                   orderby c.Year descending
                                   select c;

            foreach (var coaster in coastersByPark)
            {
                Console.WriteLine(coaster.Key + " " + coaster.Count());
            }

            //foreach (var coaster in coastersByPark)
            //{
            //    Console.WriteLine("Name: " + coaster.Name);
            //    Console.WriteLine("Park: " + coaster.Park);
            //    Console.WriteLine();
            //}

            //    var topTenTallestCoasters = GetTopTenTallestCoasters(myCoasters);
            //    foreach (var coaster in topTenTallestCoasters)
            //    {
            //        Console.WriteLine("Name: " + myCoaster.Name + " Height: " + myCoaster.Height);
            //    }
        }

        public static List<Coaster> DeserializeCoasters(string fileName)
        {
            var coasters = new List<Coaster>();
            var serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (var reader = new StreamReader(fileName))
            using (var jsonReader = new JsonTextReader(reader))
            {
                coasters = serializer.Deserialize<List<Coaster>>(jsonReader);
            }
                
            return coasters;
        }
        //public static List<Coaster> GetTopTenTallestCoasters(List<Coaster> Coasters)
        //{
        //    var topTenTallestCoasters = new List<Coaster>();
        //    myCoasters.Sort(new CoasterHeightComparer());
        //    int counter = 0;
        //    foreach (var coaster in coasters)
        //    {
        //        topTenTallestCoasters.Add(coaster);
        //        counter++;
        //        if (counter == 10)
        //            break;
        //    }
        //    return topTenTallestCoasters;
        //}
    }
}
