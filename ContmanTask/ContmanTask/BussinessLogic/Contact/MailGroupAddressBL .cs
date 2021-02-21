using ContmanTask.BussinessLogic.DataContact.MailGroup;
using ContmanTask.BussinessLogic.InterfaceContact;
using ContmanTask.Database.Models;
using ContmanTask.Database.Repository.Base;
using Gomez.Core.BusinessLogic;
using System;
using System.Linq;
namespace ContmanTask.BussinessLogic.Contact
{
    public class MailGroupAddressBL : BaseBLRepo, IMailGroupAddressBL
    {
        #region repositories
        private IUpdatableRepository<EmailGroupModel> EmailGroupRepository
        {
            get
            {
                return this.MySqlRepositoryContext.EmailGroupRepository;
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
        public bool AddMailGroup(DataContact.MailGroup.MailGroupDataRequest req)
        {
            try
            {
                EmailGroupRepository.Insert(new EmailGroupModel()
                {
                    GroupName = req.GroupName
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteMailGroup(DataContact.MailGroup.MailGroupDataRequest req)
        {
            try
            {
                var group = EmailGroupRepository.GetAll().Where(x => x.GroupId == req.GroupId).FirstOrDefault();
                EmailGroupRepository.Remove(group);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IQueryable<object> GetMailGroup(MailGroupDataRequest req)
        {
            var emailGroup = this.EmailGroupRepository.GetAll();
            IQueryable<object> query = null;
            if (req.GroupName != null)
            {
                query = from model in emailGroup
                        where model.GroupId == req.GroupId
                        && model.GroupName == req.GroupName
                        select new
                        { model.GroupId, model.GroupName };
            }
            else
            {
                query = from model in emailGroup
                        select new { model.GroupId, model.GroupName };
            }
            return query;
        }
        public IQueryable<string> GetMailsFromGroup(MailGroupDataRequest req)
        {
            var emailGroupRP = this.EmailGroupRepository.GetAll();
            var emailAddressRP = this.EmailAddressRepository.GetAll();
            IQueryable<string> query = null;
            query = from emailGroup in emailGroupRP
                    join email in emailAddressRP
                    on emailGroup.GroupId equals email.GroupId
                    where emailGroup.GroupId == req.GroupId
                    && emailGroup.GroupName == req.GroupName
                    select email.Email;
            return query;
        }
        public bool UpdateMailGroup(DataContact.MailGroup.MailGroupUpdateDataRequest req)
        {
            try
            {
                var group = EmailGroupRepository.GetAll().Where(x => x.GroupId == req.GroupId).FirstOrDefault();
                group.GroupId = req.NewGroupId;
                group.GroupName = req.NewGroupName;
                EmailGroupRepository.Update(group);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
