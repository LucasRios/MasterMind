using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Infraestrutura.NH;
using NHibernate.Criterion;

namespace Infraestrutura.Repositorios.Implementacao
{
    public class GenericoRep<T> where T : class
    {
        protected readonly ISession _session;

        public GenericoRep()
        {
            _session = NHSessionManager.ObterSessao();
        }

        public void Salvar(T entidade)
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    _session.SaveOrUpdate(entidade);
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        public void Excluir(T entidade)
        {
            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    _session.Delete(entidade);
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        public T ObterPorId(Int32 id)
        {
            T entidade = null;

            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    entidade = _session.Load<T>(id);
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
            return entidade;
        }

        public IEnumerable<T> ObterTodos()
        {
            IEnumerable<T> lista = null;

            using (var tran = _session.BeginTransaction())
            {
                try
                {
                    lista = _session.CreateCriteria<T>().List<T>();
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
            return lista;
        }
    }
}
