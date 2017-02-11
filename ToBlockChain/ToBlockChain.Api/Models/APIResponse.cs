using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace ToBlockChain.Api.Models
{
    public class APIResponse<T>
    {
        [JsonProperty(PropertyName = "responseCode")]
        public HttpStatusCode ResponseCode { get; set; }
        [JsonProperty(PropertyName = "errorMessage")]
        public string ErrorMessage { get; set; }
        [JsonProperty(PropertyName = "object")]
        public T Object { get; set; }
    }
}