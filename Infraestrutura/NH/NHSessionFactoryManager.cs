using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Context;

namespace Infraestrutura.NH
{
    public class NHSessionFactoryManager
    {
        private static ISessionFactory _sessionFactory = null;
        private static Object createLock = new Object();

        public static ISessionFactory ObterFabricaSessao()
        {
            lock (createLock)
            {
                if (_sessionFactory == null)
                {
                    FluentConfiguration config = ConstruirConfiguracao();
                    _sessionFactory = config.BuildSessionFactory();
                }
            }
            return _sessionFactory;
        }

        private static FluentConfiguration ConstruirConfiguracao()
        {
            FluentConfiguration config = Fluently.Configure()
                .Database(  MsSqlConfiguration.MsSql2008
                            .ConnectionString(ConfigurationManager.ConnectionStrings["Default"].ToString())
                            .ShowSql()
                        )
                .CurrentSessionContext<WebSessionContext>()
                .Mappings(x => x.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly())
                         )
            ;
            return config;
        }
    }
}
