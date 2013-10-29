using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Infraestrutura.Repositorios.Entidades
{
    public class Usuario
    {
        [Display(Name="Id Usuario")]
        [Key]
        public virtual Int32 Id_user { get; set; }

        [Display(Name = "Nome Usuário")]
        [Required(ErrorMessage="Campo Obrigatório.")]
        public virtual String Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório.")]
        public virtual String Sobrenome { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório.")]
        public virtual String Email { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório.")]
        public virtual String Senha { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório.")]
        public virtual DateTime Dt_nasc { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório.")]
        public virtual String Pais { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório.")]
        public virtual String Cidade { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório.")]
        public virtual String Estado { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório.")]
        public virtual String Sexo { get; set; }

    }
}
