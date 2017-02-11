using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToBlockChain.Entities
{
    public class Consumption
    {
        [JsonProperty("email_address")]
        public string Email { get; set; }

        [JsonProperty("start_date")]
        public string StartDate { get; set; }

        [JsonProperty("end_date")]
        public string EndDate { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}