using ContmanTask.BusinessLogic;
using ContmanTask.Database.Domain;
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
