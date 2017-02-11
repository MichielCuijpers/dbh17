using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToBlockChain.Api.Models
{
    public class MandateModel
    {
        [JsonProperty("emailId")]
        public string Email { get; set; }

        [JsonProperty("mobileNo")]
        public string MobileNumber { get; set; }

        [JsonProperty("smartMeter")]
        public MandateType SmartMeter { get; set; }

        [JsonProperty("SourceProfile")]
        public MandateType SourceProfile { get; set; }

        [JsonProperty("trustedParty")]
        public MandateType TrustedParty { get; set; }
        
    }
}