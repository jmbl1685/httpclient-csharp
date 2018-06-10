using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Entities.Request
{
    public class Car
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("trademark")]
        public string Trademark { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
