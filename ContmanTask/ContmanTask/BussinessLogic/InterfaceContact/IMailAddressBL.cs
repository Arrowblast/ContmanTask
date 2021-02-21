using ContmanTask.BussinessLogic.DataContact.Mail;
using System.Linq;
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
