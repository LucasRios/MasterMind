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
        }
    }
}
