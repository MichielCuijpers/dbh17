using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToBlockChain.Api.Models
{
    public class GenerationModel
    {
        [JsonProperty("emailId")]
        public string Email { get; set; }

        [JsonProperty("deviceId")]
        public string DeviceId { get; set; }

        [JsonProperty("generation")]
        public int Generation { get; set; }
    }
}