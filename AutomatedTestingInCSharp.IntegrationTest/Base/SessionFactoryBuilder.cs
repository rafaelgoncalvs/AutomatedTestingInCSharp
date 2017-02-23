using AutomatedTestingInCSharp.Infra;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;

namespace AutomatedTestingInCSharp.IntegrationTest.Base
{
    public class SessionFactoryBuilder
    {
        public static ISessionFactory Build()
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.InMemory().ShowSql())
                .Mappings(map => map.FluentMappings.AddFromAssemblyOf<TeamMap>())
                .ExposeConfiguration(config => Configuration = config)
                .BuildSessionFactory();
        }

        public static Configuration Configuration { get; set; }
    }
}
