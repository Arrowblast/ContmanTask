﻿using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ContmanTask.Database.Domain;
using ContmanTask.Database.Utils;
using System.Data.Entity;
namespace ContmanTask.Database.IoC
{
    public static class Installer
    {
        public static void Install(IWindsorContainer container)
        {
            DbConfiguration.SetConfiguration(CustomDbConfigurationProvider.CustomDbConfigurationInstance);
            container.Register(Component.For<IMySqlRepositoryContext>().ImplementedBy<MySqlRepositoryContent>().LifestylePerThread());
        }
    }
}
