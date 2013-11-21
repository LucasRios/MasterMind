using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infraestrutura.Repositorios.Entidades;
using NHibernate.Criterion;

namespace Infraestrutura.Repositorios.Implementacao
{
    public class PerguntasRep: GenericoRep<Perguntas>
    {
        public IList<Perguntas> ObterPerguntas(Int32 IdTema, Int32 IdNivel)
        {
             return base._session.CreateCriteria<Perguntas>()
                                 .Add(Restrictions.Eq("Id_tema", IdTema))
                                 .Add(Restrictions.Eq("Id_nivel", IdNivel))
                                 .List<Perguntas>();
        }

        public IList<Perguntas> ObterPerguntas(Int32 IdTema)
        {
            return base._session.CreateCriteria<Perguntas>()
                                .Add(Restrictions.Eq("Tema.Id_tema", IdTema))
                                .List<Perguntas>();
        }
    }
}
