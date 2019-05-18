using MISA.WebApi.Repository;
using MISA.WebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.Injection;
using Unity.AspNet.WebApi;

namespace MISA.WebApi.CustomerManager
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<ICustomerService, CustomerService>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IDatabaseContextFactory, DatabaseContextFactory>();
            container.RegisterType<ICustomerRepository, CustomerRepository>();
            config.DependencyResolver = new UnityResolver(container);
            //config.DependencyResolver = new UnityDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
