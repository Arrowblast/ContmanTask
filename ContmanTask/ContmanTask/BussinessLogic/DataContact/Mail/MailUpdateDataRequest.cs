using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContmanTask.BussinessLogic.DataContact.Mail
{
    public class MailGroupUpdateDataRequest
    {
        public string Mail { get; set;}
        public string NewMail { get; set;}
        public int NewGroupId { get; set;}
    }
}
