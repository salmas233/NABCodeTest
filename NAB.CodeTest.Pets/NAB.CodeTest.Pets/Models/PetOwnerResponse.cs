using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace NAB.CodeTest.Pets.Models
{
    public class PetOwnerResponse
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Gender gender { get; set; }
        public List<string> catNames { get; set; }
    }
}