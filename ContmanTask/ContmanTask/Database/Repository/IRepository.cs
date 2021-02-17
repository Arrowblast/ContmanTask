using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContmanTask.Database.Repository.Base
{
    public interface IRepository<TModel>
    {
        IQueryable<TModel> GetAll();
    }
}
