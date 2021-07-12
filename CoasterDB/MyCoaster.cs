using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CoasterDB
{

    public class RootObject
    {
        public MyCoaster[] MyCoaster { get; set; }
    }

    public class MyCoaster
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        
        [JsonProperty(PropertyName = "park")]
        public string Park { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "design")]
        public string Design { get; set; }

        [JsonProperty(PropertyName = "make")]
        public string Make { get; set; }

        [JsonProperty(PropertyName = "length")]
        public double? Length { get; set; }

        [JsonProperty(PropertyName = "height")]
        public double Height { get; set; }

        [JsonProperty(PropertyName = "speed")]
        public double Speed { get; set; }

        [JsonProperty(PropertyName = "inversions")]
        public int Inversions { get; set; }

        [JsonProperty(PropertyName = "year")]
        public int Year { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "otherNames")]
        public string[] OtherNames { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
    }

}
