using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Infraestrutura.Repositorios.Entidades
{
    class Perfil
    {
        [Display(Name = "Id Perfil")]
        public virtual Int32 Id_Perfil { get; set; }

        [Display(Name = "Descrição Perfil")]
        public virtual String descricao { get; set; }
    }
}
