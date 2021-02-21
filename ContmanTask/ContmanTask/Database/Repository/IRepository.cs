using System.Linq;
namespace ContmanTask.Database.Repository.Base
{
    public interface IRepository<TModel>
    {
        IQueryable<TModel> GetAll();
    }
}
