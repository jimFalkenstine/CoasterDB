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
            Console.SetBufferSize(80, 1700);
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "coasters.json");
            var coasters = DeserializeCoasters(fileName);

            //var kICoasters = from c in coasters
            //                   where c.Park == "Kings Island"
            //                   select c;

            //var KICoasters = coasters.Where(c => c.Park == "Kings Island");

            //var removedCoasters = from c in coasters
            //                        where c.Status == "Removed"
            //                        select c;

            //var removedCoasters = coasters.Where(c => c.Status == "Removed");

            //var coastersByPark = from c in coasters
            //                       group c by c.Park;

            //var coastersByPark = coasters.GroupBy(c => c.Park);

            //var coastersByYear = from c in coasters
            //                       orderby c.Year descending
            //                       select c;

            //var coastersByYear = coasters.OrderByDescending(c => c.Year);

            //Console.WriteLine("Welcome to CoasterDB.");
            //Console.WriteLine("Enter a coaster name");
            //string input = Console.ReadLine();

            //List<Coaster> Search = coasters.FindAll(c => c.Name == input ? true : false);
            //foreach (var coaster in coasters) 
            //{

            //}

            //coasters.Sort();
            //foreach (var coaster in coasters) 
            //{
            //    Console.WriteLine("Name: " + coaster.Name);
            //    Console.WriteLine("Park: " + coaster.Park);
            //    Console.WriteLine("Type: " + coaster.Type);
            //    Console.WriteLine("Make: " + coaster.Make);
            //    Console.WriteLine("Length: " + coaster.Length + " ft");
            //    Console.WriteLine("Height: " + coaster.Height + " ft");
            //    Console.WriteLine("Speed: " + coaster.Speed + " mph");
            //    Console.WriteLine("Inversions: " + coaster.Inversions);
            //    Console.WriteLine("Year: " + coaster.Year);
            //    Console.WriteLine("Status: " + coaster.Status);
            //    Console.WriteLine("Country: " + coaster.Country);
            //    Console.WriteLine(" ");
            //}

            //foreach (var coaster in coastersByPark)
            //{
            //    Console.WriteLine(coaster.Key + " " + coaster.Count());
            //}

            //foreach (var coaster in coastersByPark)
            //{
            //    Console.WriteLine("Name: " + coaster.Name);
            //    Console.WriteLine("Park: " + coaster.Park);
            //    Console.WriteLine();
            //}

            var topTenTallestCoasters = GetTopTenTallestCoasters(coasters);
            Console.WriteLine("Top Ten Tallest Coasters");
            Console.WriteLine("");
            foreach (var coaster in topTenTallestCoasters)
            {
                Console.WriteLine("Name: " + coaster.Name);
                Console.WriteLine("Park: " + coaster.Park);
                Console.WriteLine("Height: " + coaster.Height + " ft");
                Console.WriteLine("");
            }

            var topTenLongestCoasters = GetTopTenLongestCoasters(coasters);
            Console.WriteLine("Top Ten Longest Coasters");
            Console.WriteLine("");
            foreach (var coaster in topTenLongestCoasters)
            {
                Console.WriteLine("Name: " + coaster.Name);
                Console.WriteLine("Park: " + coaster.Park);
                Console.WriteLine("Length: " + coaster.Length + " ft");
                Console.WriteLine("");
            }

            var topTenFastestCoasters = GetTopTenFastestCoasters(coasters);
            Console.WriteLine("Top Ten Fastest Coasters");
            Console.WriteLine("");
            foreach (var coaster in topTenFastestCoasters)
            {
                Console.WriteLine("Name: " + coaster.Name);
                Console.WriteLine("Park: " + coaster.Park);
                Console.WriteLine("Speed: " + coaster.Speed + " mph");
                Console.WriteLine("");
            }

            var topTenMostInversions = GetTopTenMostInversions(coasters);
            Console.WriteLine("Top Ten Coasters With The Most Inversions");
            Console.WriteLine("");
            foreach (var coaster in topTenMostInversions)
            {
                Console.WriteLine("Name: " + coaster.Name);
                Console.WriteLine("Park: " + coaster.Park);
                Console.WriteLine("Inversions: " + coaster.Inversions);
                Console.WriteLine("");
            }
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
        public static List<Coaster> GetTopTenTallestCoasters(List<Coaster> Coasters)
        {
            var topTenTallestCoasters = new List<Coaster>();
            Coasters.Sort(new CoasterHeightComparer());
            int counter = 0;
            foreach (var coaster in Coasters)
            {
                topTenTallestCoasters.Add(coaster);
                counter++;
                if (counter == 10)
                    break;
            }
            return topTenTallestCoasters;
        }
        public static List<Coaster> GetTopTenLongestCoasters(List<Coaster> Coasters)
        {
            var topTenLongestCoasters = new List<Coaster>();
            Coasters.Sort(new CoasterLengthComparer());
            int counter = 0;
            foreach (var coaster in Coasters)
            {
                topTenLongestCoasters.Add(coaster);
                counter++;
                if (counter == 10)
                    break;
            }
            return topTenLongestCoasters;
        }
        public static List<Coaster> GetTopTenFastestCoasters(List<Coaster> Coasters)
        {
            var topTenFastestCoasters = new List<Coaster>();
            Coasters.Sort(new CoasterSpeedComparer());
            int counter = 0;
            foreach (var coaster in Coasters)
            {
                topTenFastestCoasters.Add(coaster);
                counter++;
                if (counter == 10)
                    break;
            }
            return topTenFastestCoasters;
        }

        public static List<Coaster> GetTopTenMostInversions(List<Coaster> Coasters)
        {
            var topTenMostInversions = new List<Coaster>();
            Coasters.Sort(new CoasterInversionComparer());
            int counter = 0;
            foreach (var coaster in Coasters)
            {
                topTenMostInversions.Add(coaster);
                counter++;
                if (counter == 10)
                    break;
            }
            return topTenMostInversions;
        }


    }
}
