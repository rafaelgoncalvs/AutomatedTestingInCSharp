﻿using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using IntegrationTestWithDataBaseOnMemory.Domain;
using IntegrationTestWithDataBaseOnMemory.Infra;
using NHibernate;
using NHibernate.Cfg;

namespace IntegrationTestWithDataBaseOnMemory.IntegrationTest
{
    public class SessionFactoryBuilder
    {
        public static ISessionFactory Gerar()
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.InMemory().ShowSql())
                .Mappings(map => map.FluentMappings.AddFromAssemblyOf<PersonMap>())
                .ExposeConfiguration(config => Configuration = config)
                .BuildSessionFactory();
        }

        public static Configuration Configuration { get; set; }
    }
}
