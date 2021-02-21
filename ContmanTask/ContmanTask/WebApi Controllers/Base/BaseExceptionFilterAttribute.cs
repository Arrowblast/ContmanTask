using NLog;
using System.Web.Http.Filters;
namespace ContmanTask.WebApi_Controllers.Base
{
    public class BaseExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private Logger Logger
        {
            get
            {
                return LogManager.GetCurrentClassLogger();
            }
        }
        public override void OnException(HttpActionExecutedContext context)
        {
            Logger.Error(context.Exception);
        }
    }
}
