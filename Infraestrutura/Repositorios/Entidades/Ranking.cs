using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Infraestrutura.Repositorios.Entidades
{
    public class Ranking
    {
        [Display(Name="Id_ranking")]
        public virtual Int32 Id_Ranking { get; set; }

        [Display(Name="qtde_certas")]
        public virtual Int32 qtde_certas { get; set; }

        [Display(Name="qtde_erradas")]
        public virtual Int32 qtde_erradas { get; set; } 
 
        [Display(Name="qtde_respostas")]
        public virtual Int32 qtde_respostas { get; set; }

        [Display(Name = "qtde_partidas_ganhas")]
        public virtual Int32 qtde_partidas_ganhas { get; set; } 

        public virtual Usuario Id_User { get; set; }
    }
}
