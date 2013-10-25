using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Infraestrutura.Repositorios.Entidades
{
    public class Perguntas
    {
        [Display(Name="Id")]
        public virtual Int32 Id_Perg { get; set; }
        [Display(Name = "Pergunta")]
        [Required(ErrorMessage="Campo Obrigatório.")]
        public virtual String Txt_Perg { get; set; }
    }
}
