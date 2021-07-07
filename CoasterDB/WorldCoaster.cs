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
        public WorldCoaster[] WorldCoaster { get; set; }
    }

    public class WorldCoaster
    {
        [JsonProperty(PropertyName = "length")]
        public int? Length { get; set; }
        
        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }

        [JsonProperty(PropertyName = "speed")]
        public int Speed { get; set; }

        [JsonProperty(PropertyName = "inversions")]
        public int Inversions { get; set; }

        [JsonProperty(PropertyName = "gForce")]
        public float? GForce { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "year")]
        public int Year { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string[] Type { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "park")]
        public string Park { get; set; }

        [JsonProperty(PropertyName = "model")]
        public string Model { get; set; } 
    }

}
