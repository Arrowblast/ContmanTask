using System;
using System.Collections.Generic;
using System.Linq;

using ContmanTask.BussinessLogic.DataContact.Account;
using ContmanTask.BussinessLogic.InterfaceContact;
using ContmanTask.WebApi_Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
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
        // GET: api/<AccountController>
        [HttpGet]
        [Authorize]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AccountController>/5
        [HttpGet("GetData")]
        [Authorize]
        public IActionResult GetData(AccountDataRequest req)
        {
            var result = AccountBL.Login(req);
            return Ok(result);
        }

        // POST api/<AccountController>
        [HttpPost("PostData")]
        [Authorize]
        public IActionResult PostData([FromBody] AccountDataRequest req)
        {
            var result = AccountBL.CreateAccount(req);
            return Ok(result);
        }
        [HttpGet("Token")]
        public IActionResult GetToken()
        {
            var client = new RestClient("https://dev-d39hr1fk.eu.auth0.com/oauth/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", "{\"client_id\":\"pEXWhoaZdp3W1AhiXNzQMt2xAmyH9T3Q\",\"client_secret\":\"B65m4EqL6IQceG2vPtijL6aYYzLOcMZ6Rx4qZjLObevXUTlMd9x1BKKsTKwraHkU\",\"audience\":\"https://localhost:1410\",\"grant_type\":\"client_credentials\"}", ParameterType.RequestBody);
            var token = client.Execute(request);
            return Ok(token.Content);
        }
        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
