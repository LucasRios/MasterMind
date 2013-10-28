using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Infraestrutura.Repositorios.Entidades
{
    public class Cadastro
    {
        [Required]
        [Key]
        [Display(Name = "ID")]
        public virtual Int32 id_user { get; set; }

        [Required]
        [Display(Name = "Usuário")]
        public virtual string usuario { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public virtual string Nome1 { get; set; }

        [Required]
        [Display(Name = "Sobrenome")]
        public virtual string sobrenome { get; set; }

        [Required]
        [Display(Name = "País")]
        public virtual string pais { get; set; }

        [Required]
        [Display(Name = "Cidade")]
        public virtual string cidade { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public virtual string estado { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public virtual string email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Data de Nascimento")]
        public virtual string dt_nasc { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve conter no mínimo {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public virtual string Senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [Compare("Senha", ErrorMessage = "A senha não condiz com a confirmação")]
        public virtual string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha Atual")]
        public string OldPassword { get; set; }
    }
}
