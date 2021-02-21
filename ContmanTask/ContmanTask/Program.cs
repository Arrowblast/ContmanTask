using Castle.Windsor;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NLog;
using System;
namespace ContmanTask
{
#pragma warning disable CS1591
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
#pragma warning restore CS1591
}
