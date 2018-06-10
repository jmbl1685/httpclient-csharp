using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Entities.Response
{
    public class DataResponse<T> : IDataResponse<T> where T : class
    {
        [JsonProperty("data")]
        public List<T> Data { get; set; }
    }
}
