using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Infraestrutura.Repositorios.Entidades.Map
{
    public class CadastroMap : ClassMap<Cadastro>
    {
        public CadastroMap()
        {
            Table("Cadastro");
            Id(x => x.id_user, "id_user").GeneratedBy.Identity();
            Map(x => x.usuario);
            Map(x => x.sobrenome);
            Map(x => x.Nome1);
            Map(x => x.pais);
            Map(x => x.cidade);
            Map(x => x.estado);
            Map(x => x.email);
            Map(x => x.dt_nasc);
            Map(x => x.Senha);

        }
    }
}
