using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Windsor;
using ContmanTask.BussinessLogic.InterfaceContact;
using ContmanTask.WebApi_Controllers.Base;
using ContmanTask.BussinessLogic.DataContact.Mail;
using ContmanTask.BussinessLogic.DataContact.MailGroup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContmanTask.WebApi_Controllers
{
    [Route("api/Mailer")]
    [ApiController]
    public class MailerController : BaseController
    {
        #region IoC
        private IMailAddressBL MailAddressBL
        {
            get
            {
                return WindsorContainer.Resolve<IMailAddressBL>();
            }
        }
        private IMailGroupAddressBL MailGroupBL
        {
            get
            {
                return WindsorContainer.Resolve<IMailGroupAddressBL>();
            }
        }
        #endregion
        

        // GET api/<MailerController>/5
        [HttpGet("GetMail")]
        [Authorize]
        public IActionResult GetMail([FromBody] MailDataRequest req)
        {
            var result = MailAddressBL.GetMail(req);
            return Ok(result.ToList());
        }
        [HttpGet("GetAllMail")]
        [Authorize]
        public IActionResult GetAllMail()
        {
            var req = new MailDataRequest();
            var result = MailAddressBL.GetMail(req);
            return Ok(result.ToList());
        }

        // POST api/<MailerController>
        [HttpPost("AddMail")]
        [Authorize]
        public IActionResult AddMail([FromBody] MailDataRequest req)
        {
            var result = MailAddressBL.AddMail(req);
            return Ok(result);
        }

        // PUT api/<MailerController>/5
        [HttpPut("UpdateMail")]
        [Authorize]
        public IActionResult PutMail([FromBody] MailUpdateDataRequest req)
        {
            var result = MailAddressBL.UpdateMail(req);
            return Ok(result);
        }

        // DELETE api/<MailerController>/5
        [HttpDelete("DeleteMail")]
        [Authorize]
        public IActionResult DeleteMail([FromBody] MailDataRequest req)
        {
            var result = MailAddressBL.DeleteMail(req);
            return Ok(result);
        }
        [HttpGet("GetMailGroup")]
        [Authorize]
        public IActionResult GetMailGroup([FromBody] MailGroupDataRequest req)
        {
            var result = MailGroupBL.GetMailGroup(req);
            return Ok(result.ToList());
        }
        [HttpGet("GetAllMailGroup")]
        [Authorize]
        public IActionResult GetAllMailGroup()
        {
            var req = new MailGroupDataRequest();
            var result = MailGroupBL.GetMailGroup(req);
            return Ok(result.ToList());
        }

        // POST api/<MailerController>
        [HttpPost("AddMailGroup")]
        [Authorize]
        public IActionResult AddMailGroup([FromBody] MailGroupDataRequest req)
        {
            var result = MailGroupBL.AddMailGroup(req);
            return Ok(result);
        }

        // PUT api/<MailerController>/5
        [HttpPut("UpdateMailGroup")]
        [Authorize]
        public IActionResult UpdateMailGroup([FromBody] MailGroupUpdateDataRequest req)
        {
            var result = MailGroupBL.UpdateMailGroup(req);
            return Ok(result);
        }

        // DELETE api/<MailerController>/5
        [HttpDelete("DeleteMailGroup")]
        [Authorize]
        public IActionResult DeleteMailGroup([FromBody] MailGroupDataRequest req)
        {
            var result = MailGroupBL.DeleteMailGroup(req);
            return Ok(result);
        }
    }
}
