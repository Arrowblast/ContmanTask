using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ContmanTask.Database.Domain;
using ContmanTask.Database.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContmanTask.Database.IoC
{
    public static class Installer
    {
        public static void Install(IWindsorContainer container)
        {
            DbConfiguration.SetConfiguration(CustomDbConfigurationProvider.CustomDbConfigurationInstance);
            //TODO: poprawić kiedy będzie już wiadomo jaką aplikacje tworzymy
            container.Register(Component.For<IMySqlRepositoryContext>().ImplementedBy<MySqlRepositoryContent>().LifestylePerThread());
        }
    }
}
