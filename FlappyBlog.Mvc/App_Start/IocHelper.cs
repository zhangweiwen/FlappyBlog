using System.Web.Mvc;
using Autofac;
using Autofac.Extras.DynamicProxy2;
using Autofac.Integration.Mvc;
using FlappyBlog.Application;
using FlappyBlog.Application.Implements;
using FlappyBlog.Domain.Mappings;
using FlappyBlog.Infrastructure.Aop;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace FlappyBlog.Mvc.App_Start
{
    public class IocHelper
    {
        private const string DbScriptFile = @"flappy-blog.sql";

        private static readonly ContainerBuilder Builder = new ContainerBuilder();

        public static IContainer Container { get; private set; }

        public static void Init()
        {
            RegisterNHibernate();
            RegisterInterceptor();
            RegisterAppServices();
            RegisterControllers();
            Container = Builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
        }

        private static void RegisterControllers()
        {
            Builder.RegisterControllers(typeof(IocHelper).Assembly);
        }

        private static void RegisterNHibernate()
        {
            Builder.Register(c => BuildSessionFactory()).As<ISessionFactory>().SingleInstance();
        }

        private static void RegisterInterceptor()
        {
            Builder.RegisterType<LogInterceptor>().AsSelf();
            Builder.RegisterType<WatchInterceptor>().AsSelf();
            Builder.Register(c =>
            {
                var sessionFactory = c.Resolve<ISessionFactory>();
                return new NHibernateInterceptor(sessionFactory);
            }).AsSelf();
        }

        private static void RegisterAppServices()
        {
            Builder.Register(c =>
            {
                var sessionFactory = c.Resolve<ISessionFactory>();
                return new TagService { SessionFactory = sessionFactory };
            }).As<ITagService>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(WatchInterceptor), typeof(NHibernateInterceptor), typeof(LogInterceptor));
        }

        public static ISessionFactory BuildSessionFactory(bool buildTables = false)
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.ShowSql()
                .ConnectionString(c => c.FromConnectionStringWithKey("blog")))
                .CurrentSessionContext("web")
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>()).ExposeConfiguration(c =>
                {
                    if (buildTables)
                    {
                        var schema = new SchemaExport(c);
                        schema.SetOutputFile(DbScriptFile).Execute(false, true, false);
                    }
                }).BuildSessionFactory();
        }
    }
}