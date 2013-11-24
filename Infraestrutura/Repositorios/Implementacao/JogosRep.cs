using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infraestrutura.Repositorios.Entidades;
using NHibernate.Criterion;
using NHibernate.SqlCommand;

namespace Infraestrutura.Repositorios.Implementacao
{
    public class JogosRep: GenericoRep<Jogos>
    {
        public IList<Jogos> ObterPorIdSala(Int32 IdSala)
        {
            Order ordem = new Order("SequenciaEntradaUsuarioSala", true);
            IList<Jogos> jogo = base._session.CreateCriteria<Jogos>()
                            .Add(Restrictions.Eq("Sala.Id_Sala", IdSala))
                            .AddOrder(ordem)
                            .List<Jogos>();
            return jogo;
        }
    }
}
