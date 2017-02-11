using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToBlockChain.Api.Models
{
    public class MandateAccountModel
    {
        [JsonProperty("emailId")]
        public string Email { get; set; }

        [JsonProperty("mobileNo")]
        public string MobileNumber { get; set; }
    }
}