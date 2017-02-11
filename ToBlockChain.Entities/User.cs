using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToBlockChain.Entities
{
    public class User
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("email_address")]
        public string Email { get; set; }

        [JsonProperty("mobile_number")]
        public string MobileNumber { get; set; }
    }
}
