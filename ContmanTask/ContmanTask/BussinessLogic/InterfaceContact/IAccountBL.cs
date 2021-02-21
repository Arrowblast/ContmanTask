using ContmanTask.BussinessLogic.DataContact.Account;
namespace ContmanTask.BussinessLogic.InterfaceContact
{
    public interface IAccountBL
    {
        public bool CreateAccount(AccountDataRequest req);
        public bool Login(AccountDataRequest req);
    }
}
