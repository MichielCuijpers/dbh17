using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToBlockChain.Api.Models
{
    public class GenerationModel
    {
        
        [JsonProperty("datum")]
        public string Date { get; set; }
        
        [JsonProperty("email_address")]
        public string Email { get; set; }

        [JsonProperty("act_consumed_solar_production_own")]
        public string ActualConsumedSolarProductionOwn { get; set; }

        [JsonProperty("act_consumed_solar_production_other")]
        public string ActualConsumedSolarProductionOther { get; set; }

        [JsonProperty("act_consumed_grey")]
        public string ActualConsumedGrey { get; set; }

        [JsonProperty("act_backdeliver_solar_production_own")]
        public string ActualBackdeliverSolarProductionOwn { get; set; }

        [JsonProperty("pred_consumed_solar_production_own")]
        public string PredConsumedSolarProductionOwn { get; set; }

        [JsonProperty("pred_consumed_grey")]
        public string PredConsumedGrey { get; set; }

        [JsonProperty("pred_backdeliver_solar_production_own")]
        public string PredBackdeliverSolarProductionOwn { get; set; }
        

    }
}