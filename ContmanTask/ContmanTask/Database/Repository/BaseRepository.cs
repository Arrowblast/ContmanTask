using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace ContmanTask.Database.Repository.Base
{
    public class BaseRepository<TModel> : IRepository<TModel>
        where TModel : class, new()
    {
        public BaseRepository(DbSet<TModel> entities)
        {
            this._entities = entities;
        }
        public IQueryable<TModel> GetAll()
        {
            return this._entities.AsNoTracking();
        }
        protected readonly DbSet<TModel> _entities;
    }
}
