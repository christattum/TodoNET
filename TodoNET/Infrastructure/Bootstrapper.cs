using System.Web.Mvc;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace TodoNET.Infrastructure
{
    public class Bootstrapper
    {
        public static IWindsorContainer ConfigureWindsor()
        {
            var container = new WindsorContainer()
                     .Install(FromAssembly.This());

            var controllerFactory = new WindsorControllerFactory(container.Kernel);

            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

            return container;

        }


    }

}
