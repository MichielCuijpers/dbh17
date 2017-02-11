using System.Threading.Tasks;
using System.Web.Http;
using ToBlockChain.Api.Models;
using Swashbuckle.Swagger.Annotations;
using System.Net;
using ToBlockChain.Api.Manager;
using ToBlockChain.Entities;
using System;

namespace ToBlockChain.Api.Controllers
{
    public class AccountController : BaseController
    {
        #region Properties

        AccountManager AccountManager { get; set; } 
        DataAnalyticsApiManager DataAnalyticsApiManager { get; set; }

        #endregion

        #region Controller
        public AccountController()
        {
            AccountManager = new AccountManager();
            DataAnalyticsApiManager = new DataAnalyticsApiManager();
        } 
        #endregion

        #region Http Verbs

        // POST api/Account/Register
        [Route("api/register")]
        [HttpPut]
        [SwaggerOperation("register")]
        [SwaggerResponse(HttpStatusCode.OK)]
        public async Task<IHttpActionResult> Register(RegisterModel model)
        {
            _logger.Info($"{ nameof(this.Register)} Register User Invoked");

            try
            {
                //1. Authorize Request
                if (!IsAuthorized())
                {
                    _logger.Warn($"{ nameof(this.Register)} Unauthorised user");
                    return Unauthorized();
                }

                _logger.Info($"{ nameof(this.Register)} Getting Payload : {GetContent()}");

                //2. Model Validation
                if (!AccountManager.ValidRegisterModel(model) || !ModelState.IsValid)
                {
                    _logger.Warn($"{ nameof(this.Register)} Invalid Model");
                    return BadRequest();
                }

                //3. Create User Model
                var user = new User
                {
                    UserId = AccountManager.GenerateUniqueId(),
                    Email = model.Email,
                    MobileNumber = model.MobileNumber
                };

                //4. Register User to Database
                var result = await DataAnalyticsApiManager.RegisterUser(user);
                _logger.Info($"{ nameof(this.Register)} User Registered");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.Info($"{ nameof(this.Register)} Error : {ex}");
                return InternalServerError();
            }
        }

        // POST api/Account/Register
        [Route("api/login")]
        [HttpPut]
        [SwaggerOperation("login")]
        [SwaggerResponse(HttpStatusCode.OK)]
        public async Task<IHttpActionResult> Login(LoginModel model)
        {
            //1. Authorize Request
            if (!IsAuthorized())
            {
                //_logger.Warn($"{ nameof(this.)} Unauthorised user");
                return Unauthorized();
            }

            //2. Model Validation
            if (!AccountManager.ValidLoginModel(model))
            {
                return BadRequest();
            }

            return Ok();
        }

        #endregion

    }
}
