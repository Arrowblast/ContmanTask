﻿using System.Data.Entity;
using System.Linq;

namespace ContmanTask.Database.Repository.Base
{
    //Base repo is readonly
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