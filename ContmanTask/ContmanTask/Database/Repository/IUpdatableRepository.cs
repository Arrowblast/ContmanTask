using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ContmanTask.Database.Repository.Base
{
    public interface IUpdatableRepository<TModel> : IRepository<TModel>
    {
        void Remove(TModel entity);
        void RemoveRange(IQueryable<TModel> query);
        void RemoveRange(IEnumerable<TModel> entities);
        void Insert(TModel entity);
        void InsertRange(IEnumerable<TModel> entities);
        void Update(TModel entity);
        void UpdateRange(IEnumerable<TModel> entities);
        void Update(IQueryable<TModel> entities, Expression<Func<TModel, TModel>> updateFactory);
    }
}
