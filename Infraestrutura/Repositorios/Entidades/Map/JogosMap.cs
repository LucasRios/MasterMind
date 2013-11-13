using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Infraestrutura.Repositorios.Entidades.Map
{
    public class JogosMap: ClassMap<Jogos>
    {
        public JogosMap()
        {
            Table("Jogos");
            Id(x => x.Id_jogo, "Id_jogo").GeneratedBy.Identity();
            References(x => x.Tema).Column("Id_tema").Cascade.None().LazyLoad();
            References(x => x.Usuario).Column("Id_user").Cascade.None().LazyLoad();
            References(x => x.Sala).Column("Id_sala").Cascade.None().LazyLoad();
            References(x => x.Niveis).Column("Id_nivel").Cascade.None().LazyLoad();
        }
    }
}
