using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infraestrutura.Repositorios.Entidades
{
    public class TrilhasTabuleiro
    {
        public virtual Int32 Id { get; set; }
        public virtual Int32 IdLayout { get; set; }
        public virtual Int32 IdTrilha { get; set; }
        public virtual Int32 IdSequencia { get; set; }
        public virtual Int32 Linha { get; set; }
        public virtual Int32 Coluna { get; set; }
    }
}
