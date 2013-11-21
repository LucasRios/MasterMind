using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infraestrutura.Repositorios.Entidades;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;

namespace Infraestrutura.Repositorios.Implementacao
{
    public class SalasRep: GenericoRep<Salas>
    {
        public IList<Usuario> ObterUsuarios(Int32 Id_Sala)
        {
            StringBuilder query = new StringBuilder();

            query.AppendLine("SELECT U.* ");
            query.AppendLine("  FROM Salas S ");
            query.AppendLine("    INNER JOIN Jogos J ");
            query.AppendLine("            ON J.Id_sala = S.Id_Sala ");
            query.AppendLine("    INNER JOIN Usuario U ");
            query.AppendLine("            ON U.Id_user = J.Id_User ");
            query.AppendLine("  WHERE S.Id_Sala = :id_sala ");

            ISQLQuery iQuery = base._session.CreateSQLQuery(query.ToString());
            iQuery.SetParameter("id_sala", Id_Sala);
            iQuery.AddEntity("U", typeof(Usuario));

            IList<Usuario> usuarios = iQuery.List<Usuario>();

            return usuarios;
        }
    }
}
