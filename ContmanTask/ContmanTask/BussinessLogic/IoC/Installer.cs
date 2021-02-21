using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ContmanTask.BussinessLogic.Contact;
using ContmanTask.BussinessLogic.InterfaceContact;
namespace ContmanTask.BussinessLogic.IoC
{
    public static class Installer
    {
        public static void Install(IWindsorContainer container)
        {
            ContmanTask.Database.IoC.Installer.Install(container);
            container.Register(Component.For<IAccountBL>().ImplementedBy<AccountBL>().LifestyleSingleton());
            container.Register(Component.For<IMailAddressBL>().ImplementedBy<MailAddressBL>().LifestyleSingleton());
            container.Register(Component.For<IMailGroupAddressBL>().ImplementedBy<MailGroupAddressBL>().LifestyleSingleton());
        }
    }
}
