using AutomatedTestingInCSharp.Application;
using AutomatedTestingInCSharp.Infra;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using SimpleInjector;

namespace AutomatedTestingInCSharp.IntegrationTest.Base
{
    [TestFixture]
    public abstract class IntegrationTestBase
    {
        private Container _container;
        private ITransaction _transacao;

        [SetUp]
        public void SetUp()
        {
            var sessionFactory = SessionFactoryBuilder.Gerar();
            Session = sessionFactory.OpenSession();

            var configuration = SessionFactoryBuilder.Configuration;
            GenerateDataBase(Session, configuration);

            ConfigDependencyInjection();

            BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            CommitTransaction();
            Session?.Dispose();
        }
        
        private static void GenerateDataBase(ISession session, Configuration configuration)
        {
            new SchemaExport(configuration).Execute(true, true, false, session.Connection, null);
        }

        private void ConfigDependencyInjection()
        {
            _container = new Container();
            _container.Register(() => Session);
            _container.RegisterAllFromAssemblyOf<PeopleRepositoryNh>(type => true);
            _container.RegisterAllFromAssemblyOf<AddPersonApplicationService>(type => true);

           
        }

        private void BeginTransaction()
        {
            _transacao = Session.BeginTransaction();
        }

        private void CommitTransaction()
        {
            _transacao.Commit();
        }

        protected T GetInstance<T>() where T : class
        {
            return _container.GetInstance<T>();
        }
        
        public ISession Session { get; set; }
    }
}
