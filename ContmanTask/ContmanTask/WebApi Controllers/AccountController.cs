using ContmanTask.BussinessLogic.DataContact.Account;
using ContmanTask.BussinessLogic.InterfaceContact;
using ContmanTask.WebApi_Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace ContmanTask.WebApi_Controllers
{
    #region IoC
    #endregion
    [Route("api/Account")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class AccountController : BaseController
    {
        #region IoC
        private IAccountBL AccountBL
        {
            get
            {
                return WindsorContainer.Resolve<IAccountBL>();
            }
        }
        #endregion
        /// <summary>
        /// Allows user to log in and generates authorization token
        /// </summary>
        [HttpGet("Login")]
        public IActionResult Login([FromBody] AccountDataRequest req)
        {
            var result = AccountBL.Login(req);
            if (result)
                return Ok(this.GetToken());
            else
                return Ok("Błędne dane logowania");
        }
        /// <summary>
        /// Allows user to create an account
        /// </summary>
        [HttpPost("CreateAccount")]
        public IActionResult CreateAccount([FromBody] AccountDataRequest req)
        {
            var result = AccountBL.CreateAccount(req);
            return Ok(result);
        }
        public string GetToken()
        {
            var client = new RestClient("https://dev-d39hr1fk.eu.auth0.com/oauth/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", "{\"client_id\":\"pEXWhoaZdp3W1AhiXNzQMt2xAmyH9T3Q\",\"client_secret\":\"B65m4EqL6IQceG2vPtijL6aYYzLOcMZ6Rx4qZjLObevXUTlMd9x1BKKsTKwraHkU\",\"audience\":\"https://localhost:1410\",\"grant_type\":\"client_credentials\"}", ParameterType.RequestBody);
            var token = client.Execute(request);
            return token.Content;
        }
    }
}
