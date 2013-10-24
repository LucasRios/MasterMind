using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Context;

namespace Infraestrutura.NH
{
    public class NHSessionManager
    {
        public static ISession ObterSessao()
        {
            if (!WebSessionContext.HasBind(NHSessionFactoryManager.ObterFabricaSessao()))
            {
                WebSessionContext.Bind(NHSessionFactoryManager.ObterFabricaSessao().OpenSession());
            }
            return NHSessionFactoryManager.ObterFabricaSessao().GetCurrentSession();
        }

        public static void FecharSessao()
        {
            if (WebSessionContext.HasBind(NHSessionFactoryManager.ObterFabricaSessao()))
                NHSessionFactoryManager.ObterFabricaSessao().GetCurrentSession().Close();
            WebSessionContext.Unbind(NHSessionFactoryManager.ObterFabricaSessao());

        }
    }
}
