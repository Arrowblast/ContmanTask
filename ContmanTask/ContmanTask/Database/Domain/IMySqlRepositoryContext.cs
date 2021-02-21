using ContmanTask.Database.Models;
using ContmanTask.Database.Repository.Base;
namespace ContmanTask.Database.Domain
{
    public interface IMySqlRepositoryContext
    {
        IUpdatableRepository<AccountModel> AccountRepository { get; }
        IUpdatableRepository<EmailAddressModel> EmailAddressRepository { get; }
        IUpdatableRepository<EmailGroupModel> EmailGroupRepository { get; }
    }
}
