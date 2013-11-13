using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Infraestrutura.Repositorios.Entidades.Map
{
    class NivelMap: ClassMap<Nivel>
    {
        public NivelMap()
        {
            Table("Nivel");
            Id(x => x.Id_Nivel, "Id_nivel").GeneratedBy.Identity();
            Map(x => x.descricao);
        }
    }
}
