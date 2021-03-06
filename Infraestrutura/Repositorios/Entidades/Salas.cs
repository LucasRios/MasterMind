﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Infraestrutura.Repositorios.Entidades
{
    public class Salas
    {
        public Salas()
        {
            Niveis = new Nivel();
        }
        [Display(Name = "Id_sala")]
        [Key]
        public virtual Int32 Id_Sala { get; set; }

        [Display(Name = "Descrição Sala")]
        [Required(ErrorMessage = "Campo Obrigatório.")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        public virtual String Sala { get; set; }

        [Display(Name = "Perfil")]
        public virtual Int32 Perfil { get; set; }

        [Display(Name = "qtde_usu")]
        public virtual Int32 qtde_usu { get; set; }

        [Display(Name = "Senha")]
        [StringLength(25, ErrorMessage = "Máximo 25 caracteres.")]
        public virtual String Senha { get; set; }

        public virtual Int32 Id_Usuario { get; set; }
        public virtual Int32 Fechada { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual String Desc_perfil { get; set; }
        public virtual Nivel Niveis { get; set; }

        public virtual Int32 IdPerguntaAtual { get; set; }
        public virtual DateTime? DataPergunta { get; set; }
        public virtual DateTime? DataResposta { get; set; }
    }
}
