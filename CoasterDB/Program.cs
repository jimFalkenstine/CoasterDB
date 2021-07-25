﻿using System;
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
            MainMenu();

            //var KICoasters = coasters.Where(c => c.Park == "Kings Island");

            //var removedCoasters = coasters.Where(c => c.Status == "Removed");

            //var coastersByPark = coasters.GroupBy(c => c.Park);

            //var coastersByYear = coasters.OrderByDescending(c => c.Year);

            //Console.WriteLine("Enter a coaster name");
            //string input = Console.ReadLine();

            //List<Coaster> Search = coasters.FindAll(c => c.Name == input ? true : false);
            //foreach (var coaster in coasters) 
            //{

            //}

            //coasters.OrderBy(c => c.Name).Take(10);
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

        }

        static void MainMenu() 
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "coasters.json");
            var coasters = DeserializeCoasters(fileName);

            Console.Clear();
            Console.WriteLine("Welcome to CoasterDB - The Roller Coaster Database");
            Console.WriteLine("");
            Console.WriteLine("Option 1. Top Ten Coaster Lists");
            Console.WriteLine("Option 2. Coaster Counts");
            Console.WriteLine("Option 3. Exit");
            Console.WriteLine("Option 4. All Coasters");
            Console.WriteLine("");
            Console.WriteLine("Please type the Option Number to navigate");
            
            var myOptions = Console.ReadLine();

            switch (myOptions) 
            {
                case "1":
                    TopTenListMenu();
                    break;

                case "2":
                    CoasterCountMenu();
                    break;

                case "3":
                    System.Environment.Exit(1);
                    break;

                case "4":
                    Console.Clear();
                    var firstTenCoasters = coasters.OrderBy(c => c.Name).Take(10);
                    foreach (var coaster in firstTenCoasters)
                    {
                        Console.WriteLine("Name: " + coaster.Name);
                        Console.WriteLine("Park: " + coaster.Park);
                        Console.WriteLine("Type: " + coaster.Type);
                        Console.WriteLine("Make: " + coaster.Make);
                        Console.WriteLine("Length: " + coaster.Length + " ft");
                        Console.WriteLine("Height: " + coaster.Height + " ft");
                        Console.WriteLine("Speed: " + coaster.Speed + " mph");
                        Console.WriteLine("Inversions: " + coaster.Inversions);
                        Console.WriteLine("Year: " + coaster.Year);
                        Console.WriteLine("Status: " + coaster.Status);
                        Console.WriteLine("Country: " + coaster.Country);
                        Console.WriteLine(" ");
                    }
                    Console.WriteLine("Press Enter to return to the Main Menu");
                    Console.ReadLine();
                    break;
            }

            MainMenu();
        }
        static void CoasterCountMenu()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "coasters.json");
            var coasters = DeserializeCoasters(fileName);

            Console.Clear();
            Console.WriteLine("Coaster Counts");
            Console.WriteLine("");
            Console.WriteLine("Total Coaster Count " + coasters.Count());
            Console.WriteLine("");
            Console.WriteLine("Option 1. Coaster Count by Park");
            Console.WriteLine("Option 2. Coaster Count by Type");
            Console.WriteLine("Option 3. Coaster Count by Design");
            Console.WriteLine("Option 4. Coaster Count by Make");
            Console.WriteLine("Option 5. Coaster Count by Status");
            Console.WriteLine("Option 6. Coaster Count by Country");
            Console.WriteLine("Option 7. Return to Main Menu");
            Console.WriteLine("");
            Console.WriteLine("Please type the Option Number to navigate");

            var myCountOptions = Console.ReadLine();

            switch (myCountOptions)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Coaster Count by Park");
                    Console.WriteLine("");
                    var coastersByPark = coasters.GroupBy(c => c.Park);
                    Console.WriteLine("Total Park Count " + coastersByPark.Count());
                    Console.WriteLine("");
                    foreach (var coaster in coastersByPark)
                    {
                        Console.WriteLine(coaster.Key + " " + coaster.Count());
                        Console.WriteLine("");
                    }
                    Console.WriteLine("Press Enter to return to Coaster Count Menu");
                    Console.ReadLine();
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("Coaster Count by Type");
                    Console.WriteLine("");
                    var coastersByType = coasters.GroupBy(c => c.Type);
                    Console.WriteLine("Total Type Count " + coastersByType.Count());
                    Console.WriteLine("");
                    foreach (var coaster in coastersByType)
                    {
                        Console.WriteLine(coaster.Key + " " + coaster.Count());
                        Console.WriteLine("");
                    }
                    Console.WriteLine("Press Enter to return to Coaster Count Menu");
                    Console.ReadLine();
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("Coaster Count by Design");
                    Console.WriteLine("");
                    var coastersByDesign = coasters.GroupBy(c => c.Design);
                    Console.WriteLine("Total Design Count " + coastersByDesign.Count());
                    Console.WriteLine("");
                    foreach (var coaster in coastersByDesign)
                    {
                        Console.WriteLine(coaster.Key + " " + coaster.Count());
                        Console.WriteLine("");
                    }
                    Console.WriteLine("Press Enter to return to Coaster Count Menu");
                    Console.ReadLine();
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("Coaster Count by Make");
                    Console.WriteLine("");
                    var coastersByMake = coasters.GroupBy(c => c.Make);
                    Console.WriteLine("Total Make Count " + coastersByMake.Count());
                    Console.WriteLine("");
                    foreach (var coaster in coastersByMake)
                    {
                        Console.WriteLine(coaster.Key + " " + coaster.Count());
                        Console.WriteLine("");
                    }
                    Console.WriteLine("Press Enter to return to Coaster Count Menu");
                    Console.ReadLine();
                    break;

                case "5":
                    Console.Clear();
                    Console.WriteLine("Coaster Count by Status");
                    Console.WriteLine("");
                    var coastersByStatus = coasters.GroupBy(c => c.Status);
                    Console.WriteLine("Total Status Count " + coastersByStatus.Count());
                    Console.WriteLine("");
                    foreach (var coaster in coastersByStatus)
                    {
                        Console.WriteLine(coaster.Key + " " + coaster.Count());
                        Console.WriteLine("");
                    }
                    Console.WriteLine("Press Enter to return to Coaster Count Menu");
                    Console.ReadLine();
                    break;

                case "6":
                    Console.Clear();
                    Console.WriteLine("Coaster Count by Country");
                    Console.WriteLine("");
                    var coastersByCountry = coasters.GroupBy(c => c.Country);
                    Console.WriteLine("Total Country Count " + coastersByCountry.Count());
                    Console.WriteLine("");
                    foreach (var coaster in coastersByCountry)
                    {
                        Console.WriteLine(coaster.Key + " " + coaster.Count());
                        Console.WriteLine("");
                    }
                    Console.WriteLine("Press Enter to return to Coaster Count Menu");
                    Console.ReadLine();
                    break;

                case "7":
                    MainMenu();
                    break;
            }
            CoasterCountMenu();
        }

        static void TopTenListMenu()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "coasters.json");
            var coasters = DeserializeCoasters(fileName);

            Console.Clear();
            Console.WriteLine("Top Ten Coaster Lists");
            Console.WriteLine("");
            Console.WriteLine("Option 1. Top Ten Tallest Coasters");
            Console.WriteLine("Option 2. Top Ten Longest Coasters");
            Console.WriteLine("Option 3. Top Ten Fastest Coasters");
            Console.WriteLine("Option 4. Top Ten Coasters With The Most Inversions");
            Console.WriteLine("Option 5. Return to Main Menu");
            Console.WriteLine("");
            Console.WriteLine("Please type the Option Number to navigate");

            var myTopTenListOptions = Console.ReadLine();

            switch (myTopTenListOptions)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Top Ten Tallest Coasters");
                    Console.WriteLine("");
                    var topTenTallestCoasters = GetTopTenTallestCoasters(coasters);
                    foreach (var coaster in topTenTallestCoasters)
                    {
                        Console.WriteLine("Name: " + coaster.Name);
                        Console.WriteLine("Park: " + coaster.Park);
                        Console.WriteLine("Height: " + coaster.Height + " ft");
                        Console.WriteLine("");
                    }
                    Console.WriteLine("Press Enter to return to the Top Ten Coaster List Menu");
                    Console.ReadLine();
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("Top Ten Longest Coasters");
                    Console.WriteLine("");
                    var topTenLongestCoasters = GetTopTenLongestCoasters(coasters);
                    foreach (var coaster in topTenLongestCoasters)
                    {
                        Console.WriteLine("Name: " + coaster.Name);
                        Console.WriteLine("Park: " + coaster.Park);
                        Console.WriteLine("Speed: " + coaster.Length + " ft");
                        Console.WriteLine("");
                    }
                    Console.WriteLine("Press Enter to return to the Top Ten Coaster List Menu");
                    Console.ReadLine();
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("Top Ten Fastest Coasters");
                    Console.WriteLine("");
                    var topTenFastestCoasters = GetTopTenFastestCoasters(coasters);
                    foreach (var coaster in topTenFastestCoasters)
                    {
                        Console.WriteLine("Name: " + coaster.Name);
                        Console.WriteLine("Park: " + coaster.Park);
                        Console.WriteLine("Speed: " + coaster.Speed + " mph");
                        Console.WriteLine("");
                    }
                    Console.WriteLine("Press Enter to return to the Top Ten Coaster List Menu");
                    Console.ReadLine();
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("Top Ten Coasters With The Most Inversions");
                    Console.WriteLine("");
                    var topTenMostInversions = GetTopTenMostInversions(coasters);
                    foreach (var coaster in topTenMostInversions)
                    {
                        Console.WriteLine("Name: " + coaster.Name);
                        Console.WriteLine("Park: " + coaster.Park);
                        Console.WriteLine("Inversions: " + coaster.Inversions);
                        Console.WriteLine("");
                    }
                    Console.WriteLine("Press Enter to return to the Top Ten Coaster List Menu");
                    Console.ReadLine();
                    break;

                case "5":
                    MainMenu();
                    break;
            }
            TopTenListMenu();
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
