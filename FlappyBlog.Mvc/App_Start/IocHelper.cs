using Autofac;
using FlappyBlog.Domain.Mappings;
using FlappyBlog.Mvc.Core;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace FlappyBlog.Mvc.App_Start
{
    public class IocHelper
    {
        private const string DbScriptFile = @"db.sql";
        private static readonly ContainerBuilder Builder = new ContainerBuilder();

        public static IContainer Container { get; private set; }

        public static void Init()
        {
            RegisteNHibernate();
            RegisteAppServices();
            Container = Builder.Build();
        }

        private static void RegisteNHibernate()
        {
            Builder.Register(c => BuildSessionFactory()).As<ISessionFactory>().SingleInstance();
        }

        private static void RegisteAppServices()
        {
 
        }

        public static ISessionFactory BuildSessionFactory(bool buildTables = false)
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.ShowSql()
                .ConnectionString(c => c.FromConnectionStringWithKey("blog")))
                .CurrentSessionContext("web")
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>()).ExposeConfiguration(c =>
                {
                    c.SetInterceptor(new SqlInterceptor());
                    if (buildTables)
                    {
                        var schema = new SchemaExport(c);
                        schema.SetOutputFile(DbScriptFile).Execute(false, true, false);
                    }
                }).BuildSessionFactory();
        }
    }
}