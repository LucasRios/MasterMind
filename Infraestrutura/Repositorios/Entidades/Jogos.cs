﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Infraestrutura.Repositorios.Entidades
{
    public class Jogos
    {
        [Display(Name="Id")]
        public virtual Int32 Id_jogo { get; set; }
        [Display(Name = "Id_sala")]
        public virtual Int32 Id_sala { get; set; }
        [Display(Name = "Id_usuario")]
        public virtual Int32 Id_usuario { get; set; }
        [Display(Name = "Id_tema")]
        public virtual Int32 Id_tema { get; set; }
        [Display(Name = "Id_nivel")]
        public virtual Int32 Id_nivel { get; set; }

        [Display(Name = "confirma_senha")]
        [StringLength(25, ErrorMessage = "Máximo 25 caracteres.")]
        public virtual String Senha { get; set; }

        public virtual Temas Tema { get; set; }
        public virtual Nivel Niveis { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Salas Sala { get; set; }        
    }
}
