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
    public class GenerationController : BaseController
    {
        SmartContractManager SmartContractManager { get; set; }

        public GenerationController()
        {
            SmartContractManager = new SmartContractManager();
        }


        // POST api/Generation
        [Route("api/generation")]
        [HttpPost]
        [SwaggerOperation("generation")]
        [SwaggerResponse(HttpStatusCode.OK)]
        public async Task<IHttpActionResult> PostGeneration(GenerationModel model)
        {
            try
            {
                //1. Authorize Request
                if (!IsAuthorized())
                {
                    _logger.Warn($"{ nameof(this.PostGeneration)} Unauthorised user");
                    return Unauthorized();
                }

                var postContent = Request.Content.ReadAsStringAsync().Result;
                _logger.Info($"{ nameof(this.PostGeneration)} Payload : {postContent}");

                var content = JsonConvert.SerializeObject(model);
                _logger.Info($"{ nameof(this.PostGeneration)} Payload : {content}");

                model = new GenerationModel
                {
                    Email = "dharmi.tanna@gmail.com",
                    ActualBackdeliverSolarProductionOwn = new List<int> { 1000, 200, 3000 }
                };
                //2. Post Generation
                var result = await SmartContractManager.SetPowerUsageGeneration(model);


                _logger.Info($"{ nameof(this.PostGeneration)} Consumption Post Success");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Error($"{ nameof(this.PostGeneration)} Error :{ex}");
            }

            return Ok();
        }

        private object PostMandate()
        {
            throw new NotImplementedException();
        }
    }
}
