using Castle.Windsor;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
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
