using ContmanTask.BussinessLogic.DataContact.MailGroup;
using System.Linq;
namespace ContmanTask.BussinessLogic.InterfaceContact
{
    public interface IMailGroupAddressBL
    {
        public IQueryable<object> GetMailGroup(MailGroupDataRequest req);
        public IQueryable<string> GetMailsFromGroup(MailGroupDataRequest req);
        public bool AddMailGroup(MailGroupDataRequest req);
        public bool UpdateMailGroup(MailGroupUpdateDataRequest req);
        public bool DeleteMailGroup(MailGroupDataRequest req);
    }
}
