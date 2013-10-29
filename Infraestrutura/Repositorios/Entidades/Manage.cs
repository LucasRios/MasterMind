using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Infraestrutura.Repositorios.Entidades
{
    public class Manage
    {
        [Display(Name = "Id Usuario")]
        public virtual Int32 Id_user { get; set; }
        public virtual String Senha { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha Atual")]
        public virtual string OldPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Nova Senha")]
        [Compare("Senha", ErrorMessage = "A nova senha não condiz com a confirmação")]
        public virtual string ConfirmPassword { get; set; }
    }
}
