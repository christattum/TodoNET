using System;
using System.IO;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using NHibernate;
using TodoNET.Infrastructure;

namespace TodoNET
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static ISessionFactory SessionFactory = CreateSessionFactory();
        private static IWindsorContainer _container;

        private static ISessionFactory CreateSessionFactory()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "nhibernate.config"));

            if (Helpers.AppSettings.IsRelease())
            {
                // use AppHarbor connection string
                cfg.SetProperty(NHibernate.Cfg.Environment.ConnectionStringName, "AppHarbor"); 
            }
            else
            {
                // use dev machine
                cfg.SetProperty(NHibernate.Cfg.Environment.ConnectionStringName, System.Environment.MachineName);
            }

            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
          //  log4net.Config.XmlConfigurator.Configure(new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config")));

            return cfg.BuildSessionFactory();

        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            _container = Bootstrapper.ConfigureWindsor();

            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(_container.Kernel));
        }

        protected void Application_End()
        {
            _container.Dispose();
        }
    }
}