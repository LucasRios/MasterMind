using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Infraestrutura.Repositorios.Entidades
{
    public class Temas
    {
        [Display(Name="Id Tema")]
        public virtual Int32 Id_tema { get; set; }

        [Display(Name = "Descrição Tema")]
        [Required(ErrorMessage="Campo Obrigatório.")]
        public virtual String Desc_tema { get; set; }

        public virtual IList<Personagens> personagens { get; protected set; }
    }
}
