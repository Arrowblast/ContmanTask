using Microsoft.EntityFrameworkCore;
namespace ContmanTask.Database.Repository.Base
{
    public interface IRepositoryContext<TContext>
        where TContext : DbContext
    {
    }
}
