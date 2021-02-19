using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Owin.Hosting;
using NLog;

namespace ContmanTask
{
    public class Program
    {
        public static readonly IWindsorContainer container = new WindsorContainer();

        public IWindsorContainer WindsorContainer
        {
            get
            {
                return container;
            }
        }
        public static void Main(string[] args)
        {

            string domainAddress = "http://+:1410";
            LogManager.GetCurrentClassLogger().Info("Service hosted " + domainAddress);
            CreateHostBuilder(args).Build().Run();
            Console.WriteLine("Service hosted " + domainAddress);
            System.Threading.Thread.Sleep(-1);
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
       Host.CreateDefaultBuilder(args).UseWindsorContainerServiceProvider()
           .ConfigureWebHostDefaults(webBuilder =>
           {
               webBuilder.UseStartup<Startup>();
              
           });
    }
        


}

