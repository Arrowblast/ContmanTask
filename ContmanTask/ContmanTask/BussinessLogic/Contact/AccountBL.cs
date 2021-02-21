using ContmanTask.BussinessLogic.DataContact.Account;
using ContmanTask.BussinessLogic.InterfaceContact;
using ContmanTask.Database.Models;
using ContmanTask.Database.Repository.Base;
using Gomez.Core.BusinessLogic;
using System;
using System.Linq;
namespace ContmanTask.BussinessLogic.Contact
{
    public class AccountBL : BaseBLRepo, IAccountBL
    {
        #region repositories
        private IUpdatableRepository<AccountModel> AccountRepository
        {
            get
            {
                return this.MySqlRepositoryContext.AccountRepository;
            }
        }
        private IUpdatableRepository<EmailAddressModel> EmailAddressRepository
        {
            get
            {
                return this.MySqlRepositoryContext.EmailAddressRepository;
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
                EmailAddressRepository.Insert(new EmailAddressModel()
                {
                    Email = req.Email,
                    AccountName = req.AccountName,
                    GroupId = null
                });
                return true;
            }
            catch (Exception)
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
            if (query.ToList().Count > 0)
                return true;
            else
                return false;
        }
    }
}
