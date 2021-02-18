using ContmanTask.BussinessLogic.DataContact.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContmanTask.BussinessLogic.InterfaceContact
{
    public interface IAccountBL
    {
        public bool CreateAccount(AccountDataRequest req);
        public bool Login(AccountDataRequest req);
    }
}
