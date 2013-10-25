using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Infraestrutura.Repositorios.Entidades.Map
{
    public class RespostasMap: ClassMap<Respostas>
    {
        public RespostasMap()
        {
            Table("Resposta");
            Id(x => x.Id_resp, "Id_resp").GeneratedBy.Identity();
            Map(x => x.Resp_txt);
            Map(x => x.OpcaoCerta);
        }
    }
}
