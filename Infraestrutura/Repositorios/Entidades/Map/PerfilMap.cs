using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Infraestrutura.Repositorios.Entidades.Map
{
    class PerfilMap: ClassMap<Perfil>
    {
        public PerfilMap()
        {
            Table("Perfil");
            Id(x => x.Id_Perfil, "Id_perfil").GeneratedBy.Identity();
            Map(x => x.descricao);
        }
    }
}
