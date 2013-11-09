using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Infraestrutura.Repositorios.Entidades.Map
{
    public class SalaMap : ClassMap<Salas>
    {
        public SalaMap()
        {
            Table("Salas");
            Id(x => x.Id_Sala, "Id_sala").GeneratedBy.Identity();
            Map(x => x.Sala);
            Map(x => x.Perfil);
            Map(x => x.Id_usuario);
            Map(x => x.Senha);
        }
    }
}
