using ContmanTask.BussinessLogic.DataContact.Account;
using ContmanTask.BussinessLogic.DataContact.Mail;
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
    public class MailAddressBL : BaseBLRepo, IMailAddressBL
    {
        #region repositories
        private IUpdatableRepository<EmailAddressModel> EmailAddressRepository
        {
            get
            {
                return this.MySqlRepositoryContext.EmailAddressRepository;
            }
        }
        #endregion
        public bool AddMail(MailDataRequest req)
        {
            try
            {

                EmailAddressRepository.Insert(new EmailAddressModel()
                {
                    Email = req.Mail,
                    AccountName = req.AccountName,
                    GroupId = (req.GroupId !=0 ? req.GroupId : null as int?)
                });
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool DeleteMail(MailDataRequest req)
        {
            try
            {
                var mail = EmailAddressRepository.GetAll().Where(x => x.Email==req.Mail).FirstOrDefault();
                EmailAddressRepository.Remove(mail);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IQueryable<string> GetMail(MailDataRequest req)
        {
            var mail = this.EmailAddressRepository.GetAll();
            IQueryable<string> query =null;
            if (req.Mail!=null)
            {
                query = from model in mail
                        where model.Email == req.Mail
                        select model.Email;
            }
            else
            {
                query = from model in mail
                        select model.Email;
            }

            return query;
        }

        public bool UpdateMail(MailUpdateDataRequest req)
        {
            try
            {
                var mail = EmailAddressRepository.GetAll().Where(x => x.Email == req.Mail).FirstOrDefault();
                mail.Email = req.NewMail;
                mail.AccountName = req.NewAccountName;
                mail.GroupId = req.NewGroupId;
                EmailAddressRepository.Update(mail);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
