using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToBlockChain.Entities.BlockChain
{
    public class User
    {
        [JsonProperty("_postCode")]
        public string PostCode { get; set; }

        [JsonProperty("_houseNumber")]
        public string HouseNumber { get; set; }

        [JsonProperty("_emailId")]
        public string Email { get; set; }

        [JsonProperty("_mobileNumber")]
        public string MobileNumber { get; set; }

        [JsonProperty("_password")]
        public string Password { get; set; }
    }
}
