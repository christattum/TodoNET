using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using NHibernate;

namespace TodoNET.Infrastructure
{
    public class NHibernateInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Here we are setting lifestyle to Transient, since we are controlling ISession lifestyle ourselves in MvcApplication
            // in any case, Castle's default lifestyle is Singleton, so it would cache and return the same instance every time

            container.Register(
                Component.For<ISession>()
                    .UsingFactoryMethod(() => MvcApplication.SessionFactory.GetCurrentSession())
                    .LifeStyle.Transient
            );
        }
    }
}