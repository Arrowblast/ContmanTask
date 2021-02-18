using ContmanTask.BusinessLogic;

using ContmanTask.Database.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomez.Core.BusinessLogic
{
    public class BaseBLRepo : BaseBL
    {
        #region protected
        protected IMySqlRepositoryContext MySqlRepositoryContext
        {
            get
            {
                return this.windsorContainer.Resolve<IMySqlRepositoryContext>();
            }
        }

        #endregion protected
    }
}
