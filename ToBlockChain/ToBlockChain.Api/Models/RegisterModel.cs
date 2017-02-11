using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToBlockChain.Api.Models
{
    public class RegisterModel
    {
        [JsonProperty("postCode")]
        public string PostCode { get; set; }

        [JsonProperty("houseNo")]
        public string HouseNumber { get; set; }

        [Required]
        [EmailAddress]
        [JsonProperty("emailId")]
        public string Email { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Mobile Number should be 10 digits")]
        [JsonProperty("mobileNo")]
        public string MobileNumber { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}