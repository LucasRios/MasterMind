using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Infraestrutura.Repositorios.Entidades.Map
{
    public class ManageMap : ClassMap<Manage>
    {
        public ManageMap()
        {
            Table("Usuario");
            Id(x => x.Id_user, "Id_user").GeneratedBy.Identity();
            Map(x => x.Nome);
            Map(x => x.Sobrenome);
            Map(x => x.Email);
            Map(x => x.Senha);
            Map(x => x.Dt_nasc);
            Map(x => x.Pais);
            Map(x => x.Cidade);
            Map(x => x.Estado);
            Map(x => x.Sexo);
            Map(x => x.imagem);
        }
    }
}
