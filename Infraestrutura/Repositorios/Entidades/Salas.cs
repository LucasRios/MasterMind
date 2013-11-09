using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Infraestrutura.Repositorios.Entidades
{
    public class Salas
    {
        [Display(Name = "Id Sala")]
        public virtual Int32 Id_Sala { get; set; }

        [Display(Name = "Descrição Sala")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        public virtual String Sala { get; set; }

        [Display(Name = "Perfil")]
        public virtual String Perfil { get; set; }

        [Display(Name = "Senha")]
        [StringLength(25, ErrorMessage = "Máximo 25 caracteres.")]
        public virtual String Senha { get; set; }

        public virtual Int32 Id_usuario { get; set; }     
    }
}
