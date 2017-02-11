using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using ToBlockChain.Api.Models;
using ToBlockChain.Configuration;
using ToBlockChain.Logging.Log4Net;

namespace ToBlockChain.Api.Controllers
{
    public class BaseController : ApiController
    {
        protected Logger _logger { get; set; }
        protected Guid _logId { get; set; }

        public BaseController()
        {
            _logId = Guid.NewGuid();
            _logger = new Logger($"{this.GetType().Name}");
            Logger.SetProperty("logid", _logId);
        }

        internal string GetContent()
        {
            Logger.SetProperty("url", $"{this.GetType().FullName}.{nameof(this.GetContent)}");
            var contnt = Request.Content.ReadAsStringAsync().Result;
            _logger.Info($"{nameof(this.GetContent)} : {string.Concat("Request Payload : ", !string.IsNullOrEmpty(contnt) ? contnt : "<payload is null>")}");
            return contnt;
        }

        #region Authorization
        internal bool IsAuthorized()
        {
            bool isAuthorized = false;

            //1. Fetch Authorization Info from Header
            var authHeader = Request.Headers.Authorization;

            //2. Validate Basic Authorization
            if (authHeader != null && authHeader.Scheme.StartsWith("Basic") && !string.IsNullOrEmpty(authHeader.Parameter))
            {
                //Extract credentials
                isAuthorized = ValidateAuthorization(authHeader);
            }
            else
            {
                isAuthorized = false;
            }

            return isAuthorized;
        }

        private bool ValidateAuthorization(AuthenticationHeaderValue authHeader)
        {
            try
            {
                //1. Fetch Substring of Authorization header "Basic"
                string encodedUsernamePassword = authHeader.Parameter.Trim();

                _logger.Info($"{nameof(this.ValidateAuthorization)} : Encoded Username Password : ${encodedUsernamePassword}");

                //2. The coding should be iso or you could use ASCII and UTF-8 decoder
                Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));

                //3. Splitting Username:Password
                int seperatorIndex = usernamePassword.IndexOf(':');
                var username = usernamePassword.Substring(0, seperatorIndex);
                var password = usernamePassword.Substring(seperatorIndex + 1);

                //4. Validate the credential with Azure B2B
                if (IsAuthorized(username, password))
                {
                    _logger.Info($"{nameof(this.ValidateAuthorization)} : Authorized user");
                    return true;
                }

                _logger.Info($"{nameof(this.ValidateAuthorization)} : Unauthorized user");
                return false;
            }
            catch (Exception ex)
            {
                _logger.Fatal($"{nameof(this.ValidateAuthorization)} : Error :", ex);
                return false;
            }
        }

        private bool IsAuthorized(string appKey, string appSecret)
        {
            //1. Get Configuration from table storage
            var configurations = ConfigurationManager.GetConfiguration("TBC");

            //2. Validate appKey and appSecret
            var result = configurations.Any(conf => conf.AppKey.Equals(appKey) && conf.AppSecret.Equals(appSecret));

            return result;
        } 
        #endregion
    }
}
