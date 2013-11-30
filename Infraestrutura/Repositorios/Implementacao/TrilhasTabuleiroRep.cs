using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infraestrutura.Repositorios.Entidades;
using NHibernate.Criterion;
using NHibernate.SqlCommand;

namespace Infraestrutura.Repositorios.Implementacao
{
    public class TrilhasTabuleiroRep: GenericoRep<TrilhasTabuleiro>
    {
        public IList<TrilhasTabuleiro> ObterTrilhas(Int32 IdLayout, Int32 IdTrilha, Int32 IdSequencia)
        {
            var lista = base._session.CreateCriteria<TrilhasTabuleiro>()
                .Add(Restrictions.Eq("IdLayout", IdLayout))
                .Add(Restrictions.Eq("IdTrilha", IdTrilha))
                .Add(Restrictions.Eq("IdSequencia", IdSequencia))
                .List<TrilhasTabuleiro>();
            return lista;
        }
    }
}
