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
using ToBlockChain.Entities;

namespace ToBlockChain.Api.Controllers
{
    public class ConsumptionController : BaseController
    {
        #region Properties

        DataAnalyticsApiManager DataAnalyticsApiManager { get; set; }
        SmartContractManager SmartContractManager { get; set; }

        #endregion

        #region Constructor

        public ConsumptionController()
        {
            DataAnalyticsApiManager = new DataAnalyticsApiManager();
            SmartContractManager = new SmartContractManager();
        }

        #endregion

        // POST api/Consumption
        [Route("api/consumption")]
        [HttpPost]
        [SwaggerOperation("consumption")]
        [SwaggerResponse(HttpStatusCode.OK)]
        public async Task<IHttpActionResult> PostConsumption(ConsumptionModel model)
        {
            //1. Authorize Request
            if (!IsAuthorized())
            {
                //_logger.Warn($"{ nameof(this.)} Unauthorised user");
                return Unauthorized();
            }

            //2. Create consumption Model
            var consumption = new Consumption
            {
                Email = model.Email,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Type = "dag"
            };

            //3. Post Consumption
            var result = await DataAnalyticsApiManager.PostConsumption(consumption);


            _logger.Info($"{ nameof(this.PostConsumption)} Consumption Post Success");

            return Ok(result);
        }
    }
}
