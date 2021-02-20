using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContmanTask.Database.Repository.Base
{
    public interface IRepositoryContext<TContext>
        where TContext: DbContext
    {
    }
}
