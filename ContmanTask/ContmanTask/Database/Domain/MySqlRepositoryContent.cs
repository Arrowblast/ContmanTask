using ContmanTask.Database.Models;
using ContmanTask.Database.Repository.Base;
namespace ContmanTask.Database.Domain
{
    public class MySqlRepositoryContent : BaseRepositoryContext<MySqlModel>, IMySqlRepositoryContext
    {
        public MySqlRepositoryContent() : base()
        {
            AccountRepository = new BaseUpdatableRepository<AccountModel, MySqlModel>(dbContext.Account, dbContext);
            EmailAddressRepository = new BaseUpdatableRepository<EmailAddressModel, MySqlModel>(dbContext.EmailAddress, dbContext);
            EmailGroupRepository = new BaseUpdatableRepository<EmailGroupModel, MySqlModel>(dbContext.EmailGroup, dbContext);
        }
        public IUpdatableRepository<AccountModel> AccountRepository { get; private set; }
        public IUpdatableRepository<EmailAddressModel> EmailAddressRepository { get; private set; }
        public IUpdatableRepository<EmailGroupModel> EmailGroupRepository { get; private set; }
    }
}
