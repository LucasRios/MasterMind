using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infraestrutura.Repositorios.Entidades.DTO
{
    public class StatusPartidaTabuleiroDTO
    {
        public Int32 Id_user { get; set; }
        public Int32 Linha { get; set; }
        public Int32 Coluna { get; set; }
        public Int32 CorPeca { get; set; }
    }
}
