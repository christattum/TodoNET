using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using TodoNET.Models;
using TodoNET.Services;

namespace TodoNET.Infrastructure
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IMembershipService>().ImplementedBy<AccountMembershipService>().LifeStyle.PerWebRequest);
            container.Register(Component.For<IFormsAuthenticationService>().ImplementedBy<FormsAuthenticationService>().LifeStyle.PerWebRequest);

        }
    }
}