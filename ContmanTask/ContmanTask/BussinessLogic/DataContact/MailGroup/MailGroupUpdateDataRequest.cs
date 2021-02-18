using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContmanTask.BussinessLogic.DataContact.MailGroup
{
    public class MailGroupUpdateDataRequest
    {
        public int GroupId { get; set;}
        public int NewGroupId { get; set;}
        public string NewGroupName { get; set;}
    }
}
