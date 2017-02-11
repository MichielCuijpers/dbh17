using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToBlockChain.Api.Models
{
    public class ConsumptionModel
    {
        [JsonProperty("email_address")]
        public string Email { get; set; }

        [JsonProperty("start_date")]
        public string StartDate { get; set; }

        [JsonProperty("end_date")]
        public string EndDate { get; set; }
    }
}