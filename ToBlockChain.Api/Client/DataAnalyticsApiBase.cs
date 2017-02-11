using Microsoft.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace ToBlockChain.Api.Client
{
    public class DataAnalyticsApiBase
    {
        protected DataAnalyticsApiClient DataAnalyticsApiClient
        {
            get;
            set;
        }

        public string Token { get; set; }

        public DataAnalyticsApiClient GetApiClient()
        {
            var apiUrl = CloudConfigurationManager.GetSetting("api:DataAnalyticsUrl");
            DataAnalyticsApiClient = new DataAnalyticsApiClient(apiUrl);
            DataAnalyticsApiClient.Token = Token;
            DataAnalyticsApiClient.Client.DefaultRequestHeaders.Accept.Clear();
            DataAnalyticsApiClient.Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return DataAnalyticsApiClient;
        }
    }
}