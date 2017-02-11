using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ToBlockChain.Api.Models;

namespace ToBlockChain.Api.Controllers
{
    public class GenerationController : BaseController
    {
        // POST api/Generation
        [Route("api/generation")]
        [HttpPost]
        [SwaggerOperation("generation")]
        [SwaggerResponse(HttpStatusCode.OK)]
        public async Task<IHttpActionResult> PostGeneration(GenerationModel model)
        {
            //1. Authorize Request
            if (!IsAuthorized())
            {
                //_logger.Warn($"{ nameof(this.)} Unauthorised user");
                return Unauthorized();
            }

            //2. 

            return Ok();
        }
    }
}
