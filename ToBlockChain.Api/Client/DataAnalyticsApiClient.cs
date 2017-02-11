using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ToBlockChain.Api.Models;

namespace ToBlockChain.Api.Client
{
    public class DataAnalyticsApiClient
    {
        #region Properties 

        public string BaseUrl { get; set; }
        public HttpClient Client { get; set; }
        public HttpContent Content { get; set; }
        public string Token { get; set; }

        #endregion

        public DataAnalyticsApiClient(string baseUrl, bool debug = false)
        {
            BaseUrl = $"{baseUrl}api/";
            Client = new HttpClient();
            Client.BaseAddress = new Uri(BaseUrl);
        }

        #region Base Methods

        public async Task<APIResponse<T>> Get<T>(string url)
        {
            try
            {
                var model = new APIResponse<T>();
                var res = Client.GetAsync(url).Result;

                string data = await res.Content.ReadAsStringAsync();
                if (res.IsSuccessStatusCode)
                {
                    model.Object = JsonConvert.DeserializeObject<T>(data);
                }
                else
                {
                    model = JsonConvert.DeserializeObject<APIResponse<T>>(data);
                }
                model.ResponseCode = res.StatusCode;

                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<APIResponse<string>> Post<T>(string url, T model)
        {
            try
            {
                var returnval = new APIResponse<string>();
                HttpContent postmodel = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var res = Client.PostAsync(url, postmodel).Result;
                if (!res.IsSuccessStatusCode)
                {
                    returnval = JsonConvert.DeserializeObject<APIResponse<string>>(await res.Content.ReadAsStringAsync());
                }
                else
                {
                    returnval.ErrorMessage = "";
                }
                returnval.ResponseCode = res.StatusCode;
                return returnval;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<APIResponse<T>> PostReturnModel<T, U>(string url, U model)
        {
            try
            {
                var returnval = new APIResponse<T>();
                HttpContent postmodel = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var res = await Client.PostAsync(url, postmodel);
                if (res.IsSuccessStatusCode)
                {
                    returnval.Object = JsonConvert.DeserializeObject<T>(await res.Content.ReadAsStringAsync());
                }
                else
                {
                    returnval = JsonConvert.DeserializeObject<APIResponse<T>>(await res.Content.ReadAsStringAsync());
                }
                returnval.ResponseCode = res.StatusCode;
                return returnval;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        #endregion
    }
}