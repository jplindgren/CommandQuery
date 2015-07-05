using Application.Command;
using Application.Command.Handler;
using Application.Command.Handler.Decorator;
using Application.Command.Result;
using Application.Dispatcher;
using Application.Event;
using Application.Event.Handler;
using Application.FakeInfra;
using Application.FakeLuceneInfra;
using Application.Validators;
using CommandQueryTest.Dispatcher;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CommandQueryTest {
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Register(GlobalConfiguration.Configuration);
        }

        public void Register(HttpConfiguration config) {
            var container = new UnityContainer();

            config.DependencyResolver = new UnityResolver(container);

            //general
            container.RegisterType<IMessageSender, MessageSender>();
            container.RegisterType<ILogger, Logger>();

            container.AddNewExtension<CommandQueryUnityExtension>();
        }

        private IDictionary<Type, Type> GetHandlersByType(Type type) {
            return (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                   from implementation in assembly.GetExportedTypes()
                   where !implementation.IsAbstract
                   where !implementation.ContainsGenericParameters
                   let services =
                       from iface in implementation.GetInterfaces()
                       where iface.IsGenericType
                       where iface.GetGenericTypeDefinition() == type
                       select iface
                   from service in services
                   select new { service, implementation }).ToDictionary(item => item.implementation, item => item.service);
        }



        //from assembly in AppDomain.CurrentDomain.GetAssemblies()
        //                                      from implementation in assembly.GetExportedTypes()
        //                                      where !implementation.IsAbstract
        //                                      where !implementation.ContainsGenericParameters
        //                                      let services =
        //                                          from iface in implementation.GetInterfaces()
        //                                          where iface.IsGenericType
        //                                          where iface.GetGenericTypeDefinition() == typeof(IEventHandler<>)
        //                                          select iface
        //                                      from service in services
        //                                      select new { service, implementation };
    } //class
}