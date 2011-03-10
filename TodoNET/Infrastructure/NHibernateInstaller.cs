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

            /* This was using the BeginRequest, EndRequest approach to open close session
             * This was very wasteful as sessions were opened for EVERY web request, even for static files!
             * This way we only open a session when actually requested
             * Also this will mean we're no longer using the CurrentSessionContext mechanism in NHiberate
             *Since Windsor is handling the WebRequest caching of the ISession via the HttpModule as setup in web.config
             * ie. <add name="PerRequestLifestyle" type="Castle.MicroKernel.Lifestyle.PerWebRequestLifestyleModule, Castle.Windsor" />
            container.Register(
                Component.For<ISession>()
                    .UsingFactoryMethod(() => MvcApplication.SessionFactory.GetCurrentSession())
                    .LifeStyle.Transient
            );
             * */

            container.Register(
               Component.For<ISession>()
                   .UsingFactoryMethod(() => MvcApplication.SessionFactory.OpenSession())
                   .LifeStyle.PerWebRequest
           );
        }
    }
}