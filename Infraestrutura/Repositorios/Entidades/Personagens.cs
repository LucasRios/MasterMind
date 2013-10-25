using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Infraestrutura.Repositorios.Entidades
{
    public class Personagens
    {
        [Display(Name="Id")]
        public virtual Int32 Id_person { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage="Campo Obrigatório.")]
        public virtual String Desc_person { get; set; }

        [Display(Name = "IdTema")]
        [Required(ErrorMessage = "Campo Obrigatório.")]
        [Range(1, Int32.MaxValue, ErrorMessage="Selecione um Tema.")]
        public virtual Int32 Id_tema { get; set; }
    }
}
