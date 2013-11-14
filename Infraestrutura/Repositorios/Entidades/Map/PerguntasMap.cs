using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Infraestrutura.Repositorios.Entidades.Map
{
    public class PerguntasMap: ClassMap<Perguntas>
    {
        public PerguntasMap()
        {
            Table("Pergunta");
            Id(x => x.Id_Perg, "Id_Perg").GeneratedBy.Identity();
            Map(x => x.Txt_Perg);
            References(x => x.Tema).Column("Id_tema").Cascade.None().LazyLoad();
            References(x => x.Niveis).Column("Id_nivel").Cascade.None().LazyLoad();

            References(x => x.Resposta1).Column("Id_resp1").ForeignKey("FK_Perg_Resp1").Cascade.All();
            References(x => x.Resposta2).Column("Id_resp2").ForeignKey("FK_Perg_Resp2").Cascade.All();
            References(x => x.Resposta3).Column("Id_resp3").ForeignKey("FK_Perg_Resp3").Cascade.All();
        }
    }
}
