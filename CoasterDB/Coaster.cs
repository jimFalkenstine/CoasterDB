using System;
using Newtonsoft.Json;

namespace CoasterDB
{

    public class RootObject
    {
        public Coaster[] Coaster { get; private set; }
    }

    public class Coaster : IComparable<Coaster>
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        [JsonProperty(PropertyName = "park")]
        public string Park { get; private set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; private set; }

        [JsonProperty(PropertyName = "design")]
        public string Design { get; private set; }

        [JsonProperty(PropertyName = "make")]
        public string Make { get; private set; }

        [JsonProperty(PropertyName = "length")]
        public double? Length { get; private set; }

        [JsonProperty(PropertyName = "height")]
        public double Height { get; private set; }

        [JsonProperty(PropertyName = "speed")]
        public double Speed { get; private set; }

        [JsonProperty(PropertyName = "inversions")]
        public int Inversions { get; private set; }

        [JsonProperty(PropertyName = "year")]
        public int Year { get; private set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; private set; }

        [JsonProperty(PropertyName = "otherNames")]
        public string[] OtherNames { get; private set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; private set; }
        
        public int CompareTo(Coaster that)
        {
            int result = this.Name.CompareTo(that.Name);

            if (result == 0)
            {
                result = this.Park.CompareTo(that.Park);
            }

            return result;
        }
    }

}
