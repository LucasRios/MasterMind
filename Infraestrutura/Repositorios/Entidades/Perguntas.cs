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
        [StringLength(256, ErrorMessage = "Máximo 256 caracteres.")]
        public virtual String Txt_Perg { get; set; }

        public virtual Temas Tema { get; set; }
        public virtual Respostas Resposta1 { get; set; }
        public virtual Respostas Resposta2 { get; set; }
        public virtual Respostas Resposta3 { get; set; }
    }
}
