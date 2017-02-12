using Newtonsoft.Json;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ToBlockChain.Api.Manager;
using ToBlockChain.Api.Models;

namespace ToBlockChain.Api.Controllers
{
    public class MandateController : BaseController
    {
        #region Properties

        SmartContractManager SmartContractManager { get; set; }

        #endregion

        #region Constructor

        public MandateController()
        {
            SmartContractManager = new SmartContractManager();
        }

        #endregion

        // POST api/Account/Register
        [Route("api/mandate/{email}/{mobileno}")]
        [HttpGet]
        [SwaggerOperation("mandate")]
        [SwaggerResponse(HttpStatusCode.OK)]
        public async Task<IHttpActionResult> GetMandate(string email, string mobileno)
        {
            //1. Authorize Request
            if (!IsAuthorized())
            {
                _logger.Warn($"{ nameof(this.GetMandate)} Unauthorised user");
                return Unauthorized();
            }

            var model = new MandateAccountModel
            {
                Email = email,
                MobileNumber = mobileno
            };
            var result = SmartContractManager.GetMandate(model);

            return Ok(result);
        }

        // POST api/Account/Register
        [Route("api/mandate")]
        [HttpPost]
        [SwaggerOperation("mandate")]
        [SwaggerResponse(HttpStatusCode.OK)]
        public async Task<IHttpActionResult> PostMandate(MandateModel model)
        {
            try
            {
                //1. Authorize Request
                if (!IsAuthorized())
                {
                    _logger.Warn($"{ nameof(this.PostMandate)} Unauthorised user");
                    return Unauthorized();
                }

                var content = JsonConvert.SerializeObject(model);
                _logger.Info($"{ nameof(this.PostMandate)} Payload : {content}");

                //2. Set Mandate to BlockChain
                var result = await SmartContractManager.SetMandate(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Error($"{ nameof(this.PostMandate)} Error : {ex}");
                return InternalServerError();
            }
        }
    }
}
