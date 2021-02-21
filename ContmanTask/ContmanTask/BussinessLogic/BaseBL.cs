using Castle.Windsor;
using NLog;
namespace ContmanTask.BusinessLogic
{
    public class BaseBL
    {
        public IWindsorContainer windsorContainer { get; set; }
        protected readonly Logger Logger = LogManager.GetCurrentClassLogger();
    }
}
