using Newtonsoft.Json;
using System;

namespace ToBlockChain.Api.Models
{
    public class MandateType
    {
        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        [JsonProperty("endDate")]
        public string EndDate { get; set; }
    }
}