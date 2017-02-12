using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToBlockChain.Entities.BlockChain
{
    public class Mandate
    {
        [JsonProperty("_emailId")]
        public string Email { get; set; }

        [JsonProperty("_mobileNumber")]
        public string MobileNumber { get; set; }

        [JsonProperty("_smActive")]
        public bool? SmartActive { get; set; }

        [JsonProperty("_smStartDate")]
        public string SmartStartDate { get; set; }

        [JsonProperty("_smEndDate")]
        public string SmartEndDate { get; set; }

        [JsonProperty("_spActive")]
        public bool? ProfileActive { get; set; }

        [JsonProperty("_spStartDate")]
        public string ProfileStartDate { get; set; }

        [JsonProperty("_spEndDate")]
        public string ProfileEndDate { get; set; }

        [JsonProperty("_tpActive")]
        public bool? TrustedPartyActive { get; set; }

        [JsonProperty("_tpStartDate")]
        public string TrustedPartyStartDate { get; set; }

        [JsonProperty("_tpEndDate")]
        public string TrustedPartyEndDate { get; set; }

    }
}
