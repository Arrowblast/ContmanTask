using NLog;
using System.Web.Http.ExceptionHandling;
namespace ContmanTask.WebApi_Controllers.Base
{
    class TraceExceptionLogger : ExceptionLogger
    {
        private Logger Logger
        {
            get
            {
                return LogManager.GetCurrentClassLogger();
            }
        }
        public override void Log(ExceptionLoggerContext context)
        {
            Logger.Error(context.ExceptionContext.Exception);
        }
    }
}
