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
        [StringLength(20, ErrorMessage = "Máximo 20 caracteres.")]
        [Required(ErrorMessage="Campo Obrigatório.")]
        public virtual String Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório.")]
        [StringLength(30, ErrorMessage = "Máximo 30 caracteres.")]
        public virtual String Sobrenome { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório.")]
        [StringLength(64, ErrorMessage = "Máximo 64 caracteres.")]
        public virtual String Email { get; set; }
        [StringLength(20, ErrorMessage = "Máximo 20 caracteres.")]
        [Required(ErrorMessage = "Campo Obrigatório.")]
        public virtual String Senha { get; set; }

        [Display(Name = "Data Nascimento")]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString="{0: dd/MM/yyyy}", ApplyFormatInEditMode=true)]
        [Required(ErrorMessage = "Campo Obrigatório.")]
        public virtual DateTime Dt_nasc { get; set; }

        [Display(Name = "País")]
        [StringLength(30, ErrorMessage = "Máximo 30 caracteres.")]
        [Required(ErrorMessage = "Campo Obrigatório.")]
        public virtual String Pais { get; set; }
        
        [Required(ErrorMessage = "Campo Obrigatório.")]
        [StringLength(30, ErrorMessage = "Máximo 30 caracteres.")]
        public virtual String Cidade { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório.")]
        [StringLength(2, ErrorMessage = "Máximo 2 caracteres.")]
        public virtual String Estado { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório.")]
        public virtual String Sexo { get; set; }

        public virtual Int32 Id_perfil { get; set; }
        public virtual Personagens Personagem { get; set; }

    }
}
