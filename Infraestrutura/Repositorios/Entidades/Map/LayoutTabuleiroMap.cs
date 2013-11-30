using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Infraestrutura.Repositorios.Entidades.Map
{
    public class LayoutTabuleiroMap : ClassMap<LayoutTabuleiro>
    {
        public LayoutTabuleiroMap()
        {
            Table("LayoutTabuleiro");
            Id(x => x.Id, "Id").GeneratedBy.Identity();
            Map(x => x.Descricao);
        }
    }
}
