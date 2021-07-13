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
            var fileName = Path.Combine(directory.FullName, "myCoasters.json");
            var myCoasters = DeserializeMyCoasters(fileName);

            var myKICoasters = from m in myCoasters
                               where m.Park == "Kings Island"
                               select m;

            var myRemovedCoasters = from m in myCoasters
                                    where m.Status == "Removed"
                                    select m;

            var myCoastersByPark = from m in myCoasters
                                   group m by m.Park;

            var myCoastersByYear = from m in myCoasters
                                   orderby m.Year descending
                                   select m;

            //foreach (var myCoaster in myCoastersByPark)
            //{
            //    Console.WriteLine(myCoaster.Key + " " + myCoaster.Count());
            //}

            foreach (var myCoaster in myCoastersByYear)
            {
                Console.WriteLine("Name: " + myCoaster.Name);
                Console.WriteLine("Park: " + myCoaster.Park);
                Console.WriteLine();
            }

            //    var topTenTallestCoasters = GetTopTenTallestCoasters(myCoasters);
            //    foreach (var myCoaster in topTenTallestCoasters)
            //    {
            //        Console.WriteLine("Name: " + myCoaster.Name + " Height: " + myCoaster.Height);
            //    }
        }

        public static List<MyCoaster> DeserializeMyCoasters(string fileName)
        {
            var myCoasters = new List<MyCoaster>();
            var serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (var reader = new StreamReader(fileName))
            using (var jsonReader = new JsonTextReader(reader))
            {
                myCoasters = serializer.Deserialize<List<MyCoaster>>(jsonReader);
            }
                
            return myCoasters;
        }
        //public static List<MyCoaster> GetTopTenTallestCoasters(List<MyCoaster> myCoasters)
        //{
        //    var topTenTallestCoasters = new List<MyCoaster>();
        //    myCoasters.Sort(new MyCoasterComparer());
        //    int counter = 0;
        //    foreach (var myCoaster in myCoasters)
        //    {
        //        topTenTallestCoasters.Add(myCoaster);
        //        counter++;
        //        if (counter == 10)
        //            break;
        //    }
        //    return topTenTallestCoasters;
        //}
    }
}
