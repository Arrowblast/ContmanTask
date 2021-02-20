using ContmanTask.BussinessLogic.DataContact.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContmanTask.BussinessLogic.InterfaceContact
{
    public interface IMailAddressBL
    {
        public IQueryable<string> GetMail(MailDataRequest req);
        public bool AddMail(MailDataRequest req);
        public bool UpdateMail(MailUpdateDataRequest req);
        public bool DeleteMail(MailDataRequest req);

    }
}
