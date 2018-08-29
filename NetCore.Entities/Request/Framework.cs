using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Entities.Request
{
    public class Framework
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("img")]
        public string ImageURL { get; set; }

        [JsonProperty("votes")]
        public int Votes { get; set; }


    }
}
