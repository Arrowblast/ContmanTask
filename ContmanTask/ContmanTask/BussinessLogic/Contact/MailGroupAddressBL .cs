using ContmanTask.BussinessLogic.DataContact.Account;
using ContmanTask.BussinessLogic.DataContact.MailGroup;
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
    public class MailGroupAddressBL : BaseBLRepo, IMailGroupBL
    {
        #region repositories
        private IUpdatableRepository<EmailGroupModel> EmailGroupRepository
        {
            get
            {
                return this.MySqlRepositoryContext.EmailGroupRepository;
            }
        }
        #endregion

        public bool AddMailGroup(DataContact.MailGroup.MailGroupDataRequest req)
        {
            try
            {
                EmailGroupRepository.Insert(new EmailGroupModel()
                {
                   GroupId = req.GroupId,
                   GroupName = req.GroupName
                });
                return true;
            }
            catch (Exception e)
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
            catch (Exception e)
            {
                return false;
            }
        }

        public IQueryable<string> GetMailGroup(MailGroupDataRequest req)
        {
            var emailGroup = this.EmailGroupRepository.GetAll();

            var query = from model in emailGroup
                        where model.GroupId == req.GroupId
                        && model.GroupName == req.GroupName
                        select model.GroupName;

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
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
