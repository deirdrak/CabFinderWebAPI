using System;
using System.Configuration;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using CabFinderDomain;
using FluentNHibernate.Cfg.Db;
using AcklenAvenue.Data.NHibernate;
using NHibernate;
using NHibernate.Context;
using Ninject;
using Ninject.Web.Common;
using DependencyResolver = CabFinderWebAPI.App_Start.DependencyResolver;

namespace CabFinderWebAPI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : NinjectHttpApplication
    {
        public static ISessionFactory SessionFactory = CreateSessionFactory();

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
           
            //AutoMapperConfiguration.Configure();
          
        }

        public WebApiApplication()
        {
            BeginRequest += MvcApplication_BeginRequest;
            EndRequest += MvcApplication_EndRequest;
        }

        private void MvcApplication_EndRequest(object sender, EventArgs e)
        {
            CurrentSessionContext.Unbind(SessionFactory).Dispose();
        }

        private void MvcApplication_BeginRequest(object sender, EventArgs e)
        {
            CurrentSessionContext.Bind(SessionFactory.OpenSession());
        }

        public static ISessionFactory CreateSessionFactory()
        {
            PostgreSQLConfiguration databaseConfiguration = PostgreSQLConfiguration.Standard.ShowSql().ConnectionString(
                x => x.FromConnectionStringWithKey("PostgreSQL"));

            ISessionFactory sessionFactory = new SessionFactoryBuilder(new MappingScheme(), databaseConfiguration)
                .Build();

            return sessionFactory;
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            GlobalConfiguration.Configuration.DependencyResolver = new DependencyResolver(kernel);

            kernel.Load(Assembly.GetExecutingAssembly());

            kernel.Bind<IRepository>().To<Repository>();
            kernel.Bind<ISession>().ToMethod(x => SessionFactory.GetCurrentSession());
            kernel.Bind<IMappingEngine>().ToConstant(Mapper.Engine);


            return kernel;
        }

    }
}