using ContmanTask.BussinessLogic.DataContact.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContmanTask.BussinessLogic.InterfaceContact
{
    public interface IMailAddressBL
    {
        public IQueryable<string> GetMail(MailGroupDataRequest req);
        public bool AddMail(MailGroupDataRequest req);
        public bool UpdateMail(MailGroupUpdateDataRequest req);
        public bool DeleteMail(MailGroupDataRequest req);

    }
}
