using Newtonsoft.Json;
using System;

namespace ToBlockChain.Api.Models
{
    public class MandateType
    {
        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("startDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty("endDate")]
        public DateTime EndDate { get; set; }
    }
}