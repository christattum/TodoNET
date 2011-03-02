using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using TodoNET.Infrastructure;

namespace TodoNET
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static ISessionFactory SessionFactory = CreateSessionFactory();
        private static IWindsorContainer _container;

        public MvcApplication()
        {
            BeginRequest += new EventHandler(MvcApplication_BeginRequest);
            EndRequest += new EventHandler(MvcApplication_EndRequest);
        }

        void MvcApplication_EndRequest(object sender, EventArgs e)
        {
            CurrentSessionContext.Unbind(SessionFactory).Dispose();
        }

        void MvcApplication_BeginRequest(object sender, EventArgs e)
        {
            CurrentSessionContext.Bind(SessionFactory.OpenSession());
        }

        private static ISessionFactory CreateSessionFactory()
        {
            var cfg = new Configuration().Configure(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "nhibernate.config"));
            cfg.SetProperty(NHibernate.Cfg.Environment.ConnectionStringName, System.Environment.MachineName);
            //NHibernateProfiler.Initialize();
            log4net.Config.XmlConfigurator.Configure();

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