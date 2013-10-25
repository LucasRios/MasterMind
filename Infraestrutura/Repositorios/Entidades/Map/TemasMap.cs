using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Infraestrutura.Repositorios.Entidades.Map
{
    public class TemasMap: ClassMap<Temas>
    {
        public TemasMap()
        {
            Table("Temas");
            Id(x => x.Id_tema, "Id_tema").GeneratedBy.Identity();
            Map(x => x.Desc_tema);
            HasMany<Personagens>(x => x.personagens).KeyColumn("Id_tema").LazyLoad().Cascade.All();
        }
    }
}
