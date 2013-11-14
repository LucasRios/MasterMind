using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Infraestrutura.Repositorios.Entidades
{
    public class Nivel
    {
        [Display(Name = "Id Nivel")]
        [Required(ErrorMessage = "Campo Obrigatório.")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Nivel inválido.")]
        public virtual Int32 Id_Nivel { get; set; }

        [Display(Name = "Descrição Nivel")]
        public virtual String descricao { get; set; }
    }
}
