using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Infraestrutura.Repositorios.Entidades.Map
{
    public class ManageMap : ClassMap<Manage>
    {
        public ManageMap()
        {
            Table("Usuario");
            Id(x => x.Id_user, "Id_user").GeneratedBy.Identity();
            Map(x => x.Senha);
        }
    }
}
