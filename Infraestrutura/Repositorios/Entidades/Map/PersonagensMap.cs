using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Infraestrutura.Repositorios.Entidades.Map
{
    public class PersonagensMap: ClassMap<Personagens>
    {
        public PersonagensMap()
        {
            Table("Personagens");
            Id(x => x.Id_person, "Id_person").GeneratedBy.Identity();
            References(x => x.Tema).Column("Id_tema").Cascade.None().LazyLoad();
            Map(x => x.Desc_person);
            Map(x => x.Imagem);
            Map(x => x.Nivel);
        }
    }
}
