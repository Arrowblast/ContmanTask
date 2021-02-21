using Castle.Windsor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
namespace ContmanTask.WebApi_Controllers.Base
{
    public class BaseController : ControllerBase
    {
        public IWindsorContainer WindsorContainer
        {
            get
            {
                return Startup.provider.GetService<IWindsorContainer>();
            }
        }
    }
}
