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
    public class ShareController : BaseController
    {
        #region Properties

        SmartContractManager SmartContractManager { get; set; }

        #endregion

        #region Constructor

        public ShareController()
        {
            SmartContractManager = new SmartContractManager();
        }

        #endregion

        // POST api/Account/Register
        [Route("api/share")]
        [HttpPost]
        [SwaggerOperation("share")]
        [SwaggerResponse(HttpStatusCode.OK)]
        public async Task<IHttpActionResult> Share(ShareModel model)
        {
            //1. Authorize Request
            if (!IsAuthorized())
            {
                _logger.Warn($"{ nameof(this.Share)} Unauthorised user");
                return Unauthorized();
            }

            var result = await SmartContractManager.Share(model);

            return Ok(result);
        }

    }
}
