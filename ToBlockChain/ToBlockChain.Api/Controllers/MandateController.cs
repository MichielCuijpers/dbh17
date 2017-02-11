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

        MandateManager MandateManager { get; set; }

        #endregion

        #region Constructor

        public MandateController()
        {
            MandateManager = new MandateManager();
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
                //_logger.Warn($"{ nameof(this.)} Unauthorised user");
                return Unauthorized();
            }

            var model = new MandateAccountModel
            {
                Email = email,
                MobileNumber = mobileno
            };
            var result = MandateManager.GetMandate(model);

            return Ok(result);
        }

        // POST api/Account/Register
        [Route("api/mandate")]
        [HttpPost]
        [SwaggerOperation("mandate")]
        [SwaggerResponse(HttpStatusCode.OK)]
        public async Task<IHttpActionResult> PostMandate(MandateModel model)
        {
            //1. Authorize Request
            if (!IsAuthorized())
            {
                //_logger.Warn($"{ nameof(this.)} Unauthorised user");
                return Unauthorized();
            }

            return Ok();
        }
    }
}
