using ContmanTask.BussinessLogic.DataContact.Account;
using ContmanTask.BussinessLogic.InterfaceContact;
using ContmanTask.Database.Models;
using ContmanTask.Database.Repository.Base;
using Gomez.Core.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContmanTask.BussinessLogic.Contact
{

    public class AccountBL : BaseBLRepo,IAccountBL
    {

        #region repositories
        private IUpdatableRepository<AccountModel> AccountRepository
        {
            get
            {
                return this.MySqlRepositoryContext.AccountRepository;
            }
        }
        #endregion
        public bool CreateAccount(AccountDataRequest req)
        {
            try
            {   
                AccountRepository.Insert(new AccountModel()
                {
                    AccountName = req.AccountName
                });
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool Login(AccountDataRequest req)
        {
            var accountData = AccountRepository.GetAll();

            var query = from model in accountData
                        where model.AccountName == req.AccountName
                        select new { model.AccountName };

            if (query.ToList().Count>0)
                return true;
            else
                return false;
        }

        
    }
}
