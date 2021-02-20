using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Z.EntityFramework.Plus;

namespace ContmanTask.Database.Repository.Base
{
    public class BaseUpdatableRepository<TModel, TContext> : BaseRepository<TModel>, IUpdatableRepository<TModel>
        where TModel : class, new()
        where TContext : DbContext, new()
    {
        protected TContext dbContext;

        public BaseUpdatableRepository(DbSet<TModel> entities, TContext context) : base(entities)
        {
            this.dbContext = context;
        }

        public void Remove(TModel entity)
        {
            try
            {
                this._entities.Attach(entity);
                this._entities.Remove(entity);
                this.dbContext.SaveChanges();
            }
            finally
            {
                dbContext.Entry(entity).State = EntityState.Detached;
            }
        }

        public void RemoveRange(IEnumerable<TModel> entities)
        {
            try
            {
                this._entities.RemoveRange(entities);
                this.dbContext.SaveChanges();
            }
            finally
            {
                foreach (var entity in entities)
                {
                    dbContext.Entry(entity).State = EntityState.Detached;
                }
            }
        }

        public void RemoveRange(IQueryable<TModel> query)
        {
            query.Delete();
        }

        public void Insert(TModel entity)
        {
            try
            {
                this._entities.Add(entity);
                this.dbContext.SaveChanges();
            }
            finally
            {
                dbContext.Entry(entity).State = EntityState.Detached;
            }
        }

        public void InsertRange(IEnumerable<TModel> entities)
        {
            try
            {

                this._entities.AddRange(entities);
                this.dbContext.SaveChanges();
            }
            finally
            {
                foreach (var entity in entities)
                {
                    dbContext.Entry(entity).State = EntityState.Detached;
                }
            }
        }

        public void Update(TModel entity)
        {
            try
            {
                this._entities.Attach(entity);
                this.dbContext.Entry(entity).State = EntityState.Modified;
                this.dbContext.SaveChanges();
            }
            finally
            {
                dbContext.Entry(entity).State = EntityState.Detached;
            }
        }

        public void UpdateRange(IEnumerable<TModel> entities)
        {
            try
            {
                this._entities.AttachRange(entities);
                foreach (var entity in entities)
                {
                    this.dbContext.Entry(entity).State = EntityState.Modified;
                }
                this.dbContext.SaveChanges();
            }
            finally
            {
                foreach (var entity in entities)
                {
                    dbContext.Entry(entity).State = EntityState.Detached;
                }
                
            }
        }


        /// <summary>
        /// NOT TESTED!!!
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="updateFactory"></param>
        public void Update(IQueryable<TModel> entities, Expression<Func<TModel, TModel>> updateFactory)
        {
            entities.Update(updateFactory);
        }
    }
}
