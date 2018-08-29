using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Entities.Request
{
    public class Todo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("userId")]
        public int UserID { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("completed")]
        public bool Completed { get; set; }


    }
}
