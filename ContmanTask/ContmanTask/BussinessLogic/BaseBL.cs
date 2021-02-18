using Castle.Windsor;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContmanTask.BusinessLogic
{
    public class BaseBL
    {
     
        public IWindsorContainer windsorContainer { get; set; }


        protected readonly Logger Logger = LogManager.GetCurrentClassLogger();
    }
}
