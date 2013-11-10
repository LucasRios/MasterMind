using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Infraestrutura.Repositorios.Entidades.Map
{
    public class RankingMap : ClassMap<Ranking>
    {
        public RankingMap()
        {
            Table("Ranking");
            Id(x => x.Id_Ranking, "Id_Ranking").GeneratedBy.Identity();
            References(x => x.Id_User).Column("Id_user").ForeignKey("FK_ranking").Cascade.None().LazyLoad();
            Map(x => x.qtde_certas);
            Map(x => x.qtde_erradas  );
            Map(x => x.qtde_respostas  );
        }
    }
}
