using Microsoft.EntityFrameworkCore;
namespace ContmanTask.Database.Repository.Base
{
    public class BaseRepositoryContext<TContext> : IRepositoryContext<TContext>
        where TContext : DbContext, new()
    {
        protected TContext dbContext;
        public BaseRepositoryContext()
        {
            dbContext = new TContext();
        }
    }
}
