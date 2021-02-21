using ContmanTask.BussinessLogic.DataContact.Mail;
using ContmanTask.BussinessLogic.DataContact.MailGroup;
using ContmanTask.BussinessLogic.InterfaceContact;
using ContmanTask.WebApi_Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace ContmanTask.WebApi_Controllers
{
    [Route("api/Mailer")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
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
        /// <summary>
        /// Allows user check if an mail exists
        /// </summary>
        [HttpGet("GetMail")]
        [Authorize]
        public IActionResult GetMail([FromBody] MailDataRequest req)
        {
            var result = MailAddressBL.GetMail(req);
            return Ok(result.ToList());
        }
        /// <summary>
        /// Gives all mails registered with api
        /// </summary>
        [HttpGet("GetAllMail")]
        [Authorize]
        public IActionResult GetAllMail()
        {
            var req = new MailDataRequest();
            var result = MailAddressBL.GetMail(req);
            return Ok(result.ToList());
        }
        /// <summary>
        /// Adds mail address to the database
        /// </summary>
        // POST api/<MailerController>
        [HttpPost("AddMail")]
        [Authorize]
        public IActionResult AddMail([FromBody] MailDataRequest req)
        {
            var result = MailAddressBL.AddMail(req);
            return Ok(result);
        }
        /// <summary>
        /// Allows to update email address, connected account name and group id
        /// </summary>
        // PUT api/<MailerController>/5
        [HttpPut("UpdateMail")]
        [Authorize]
        public IActionResult PutMail([FromBody] MailUpdateDataRequest req)
        {
            var result = MailAddressBL.UpdateMail(req);
            return Ok(result);
        }
        /// <summary>
        /// Deletes mail from database
        /// </summary>
        // DELETE api/<MailerController>/5
        [HttpDelete("DeleteMail")]
        [Authorize]
        public IActionResult DeleteMail([FromBody] MailDataRequest req)
        {
            var result = MailAddressBL.DeleteMail(req);
            return Ok(result);
        }
        /// <summary>
        /// Allows user check if an mail group exists
        /// </summary>
        [HttpGet("GetMailGroup")]
        [Authorize]
        public IActionResult GetMailGroup([FromBody] MailGroupDataRequest req)
        {
            var result = MailGroupBL.GetMailGroup(req);
            return Ok(result.ToList());
        }
        /// <summary>
        /// Gives all mail groups registered with api
        /// </summary>
        [HttpGet("GetAllMailGroup")]
        [Authorize]
        public IActionResult GetAllMailGroup()
        {
            var req = new MailGroupDataRequest();
            var result = MailGroupBL.GetMailGroup(req);
            return Ok(result.ToList());
        }
        /// <summary>
        /// Gives all mails assigned to certain group
        /// </summary>
        [HttpGet("GetMailFromGroup")]
        [Authorize]
        public IActionResult GetMailFromGroup([FromBody] MailGroupDataRequest req)
        {
            var result = MailGroupBL.GetMailsFromGroup(req);
            return Ok(result.ToList());
        }
        /// <summary>
        /// Adds mail group to the database
        /// </summary>
        [HttpPost("AddMailGroup")]
        [Authorize]
        public IActionResult AddMailGroup([FromBody] MailGroupDataRequest req)
        {
            var result = MailGroupBL.AddMailGroup(req);
            return Ok(result);
        }
        /// <summary>
        /// Allows to update email group's data
        /// </summary>
        [HttpPut("UpdateMailGroup")]
        [Authorize]
        public IActionResult UpdateMailGroup([FromBody] MailGroupUpdateDataRequest req)
        {
            var result = MailGroupBL.UpdateMailGroup(req);
            return Ok(result);
        }
        /// <summary>
        /// Deletes mail group from the database
        /// </summary>
        [HttpDelete("DeleteMailGroup")]
        [Authorize]
        public IActionResult DeleteMailGroup([FromBody] MailGroupDataRequest req)
        {
            var result = MailGroupBL.DeleteMailGroup(req);
            return Ok(result);
        }
    }
}
