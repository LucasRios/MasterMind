using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Infraestrutura.Repositorios.Entidades.Map
{
    public class TrilhasTabuleiroMap : ClassMap<TrilhasTabuleiro>
    {
        public TrilhasTabuleiroMap()
        {
            Table("TrilhasTabuleiro");
            Id(x => x.Id, "Id").GeneratedBy.Identity();
            Map(x => x.IdLayout);
            Map(x => x.IdTrilha);
            Map(x => x.IdSequencia);
            Map(x => x.Linha);
            Map(x => x.Coluna);
        }
    }
}
