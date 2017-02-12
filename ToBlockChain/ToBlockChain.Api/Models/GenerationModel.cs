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
        public List<int> ActualConsumedSolarProductionOwn { get; set; }

        [JsonProperty("act_consumed_solar_production_other")]
        public List<int> ActualConsumedSolarProductionOther { get; set; }

        [JsonProperty("act_consumed_grey")]
        public List<int> ActualConsumedGrey { get; set; }

        [JsonProperty("act_backdeliver_solar_production_own")]
        public List<int> ActualBackdeliverSolarProductionOwn { get; set; }

        [JsonProperty("pred_consumed_solar_production_own")]
        public List<int> PredConsumedSolarProductionOwn { get; set; }

        [JsonProperty("pred_consumed_grey")]
        public List<int> PredConsumedGrey { get; set; }

        [JsonProperty("pred_backdeliver_solar_production_own")]
        public List<int> PredBackdeliverSolarProductionOwn { get; set; }
        

    }
}