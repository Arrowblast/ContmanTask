using System;
using System.Collections.Generic;
using System.Linq;

using ContmanTask.BussinessLogic.DataContact.Account;
using ContmanTask.BussinessLogic.InterfaceContact;
using ContmanTask.WebApi_Controllers.Base;
using Microsoft.AspNetCore.Mvc;

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
        private IAccountBL AccountBL
        {
            get
            {
                return WindsorContainer.Resolve<IAccountBL>();
            }
        }
        // GET: api/<AccountController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AccountController>/5
        [HttpGet("GetData")]
        public IActionResult GetData(AccountDataRequest req)
        {
            var result = AccountBL.Login(req);
            return Ok(result);
        }

        // POST api/<AccountController>
        [HttpPost("PostData")]
        public IActionResult PostData([FromBody] AccountDataRequest req)
        {
            var result = AccountBL.CreateAccount(req);
            return Ok(result);
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
