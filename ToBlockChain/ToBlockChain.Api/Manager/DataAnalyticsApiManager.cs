using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ToBlockChain.Api.Client;
using ToBlockChain.Api.Models;
using ToBlockChain.Entities;

namespace ToBlockChain.Api.Manager
{
    public class DataAnalyticsApiManager : DataAnalyticsApiBase
    {
        public async Task<APIResponse<string>> RegisterUser(User model)
        {
            return await GetApiClient().Post(Urls.TriggerAddUserAndDevice, model);
        }
    }
}