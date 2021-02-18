using ContmanTask.BussinessLogic.DataContact.MailGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContmanTask.BussinessLogic.InterfaceContact
{
    public interface IMailGroupBL
    {
        public IQueryable<string> GetMailGroup(MailGroupDataRequest req);
        public bool AddMailGroup(MailGroupDataRequest req);
        public bool UpdateMailGroup(MailGroupUpdateDataRequest req);
        public bool DeleteMailGroup(MailGroupDataRequest req);
    }
}
