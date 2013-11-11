using System;
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

        public virtual Temas Tema { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Salas Sala { get; set; }        
    }
}
