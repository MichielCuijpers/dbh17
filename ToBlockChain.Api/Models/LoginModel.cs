using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToBlockChain.Api.Models
{
    public class LoginModel
    {
        [JsonProperty("emailId")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}