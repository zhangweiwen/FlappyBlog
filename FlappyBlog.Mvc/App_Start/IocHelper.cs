using Autofac;
using Autofac.Extras.DynamicProxy2;
using FlappyBlog.Application;
using FlappyBlog.Application.Implements;
using FlappyBlog.Domain.Mappings;
using FlappyBlog.Infrastructure.Aop;
using FlappyBlog.Mvc.Core;
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
            RegisteNHibernate();
            RegisteInterceptor();
            RegisteAppServices();
            Container = Builder.Build();
        }

        private static void RegisteNHibernate()
        {
            Builder.Register(c => BuildSessionFactory()).As<ISessionFactory>().SingleInstance();
        }

        private static void RegisteInterceptor()
        {
            Builder.RegisterType<Log4NetLogger>().AsSelf();
            Builder.RegisterType<WatchInterceptor>().AsSelf();
            Builder.RegisterType<NHibernateInterceptor>().AsSelf();
        }

        private static void RegisteAppServices()
        {
            Builder.Register(c =>
            {
                var sessionFactory = c.Resolve<ISessionFactory>();
                var session = sessionFactory.GetCurrentSession();
                return new TagService { Session = session };
            }).As<ITagService>()
            .EnableInterfaceInterceptors()
            .InterceptedBy(typeof(WatchInterceptor), typeof(NHibernateInterceptor), typeof(Log4NetLogger));
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