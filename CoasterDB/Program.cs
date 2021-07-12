using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

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
            var topTenTallestCoasters = GetTopTenTallestCoasters(myCoasters);
            foreach(var myCoaster in topTenTallestCoasters)
            {
                Console.WriteLine("Name: " + myCoaster.Name + " Height: " + myCoaster.Height);
            }
            fileName = Path.Combine(directory.FullName, "TopTenTallestCoasters.json");
            SerializeMyCoastersToFile(topTenTallestCoasters, fileName);
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
        public static List<MyCoaster> GetTopTenTallestCoasters(List<MyCoaster> myCoasters)
        {
            var topTenTallestCoasters = new List<MyCoaster>();
            myCoasters.Sort(new MyCoasterComparer());
            int counter = 0;
            foreach (var myCoaster in myCoasters)
            {
                topTenTallestCoasters.Add(myCoaster);
                counter++;
                if (counter == 10)
                    break;
            }
            return topTenTallestCoasters;
        }

        public static void SerializeMyCoastersToFile(List<MyCoaster> myCoasters, string fileName)
        {
            var serializer = new JsonSerializer();
            using (var writer = new StreamWriter(fileName))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                serializer.Serialize(jsonWriter, myCoasters);
            }
        }

    }
}
