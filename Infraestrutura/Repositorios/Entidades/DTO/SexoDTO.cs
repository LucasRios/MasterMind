using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infraestrutura.Repositorios.Entidades.DTO
{
    public class SexoDTO
    {
        public String Sexo {get;set;}
        public String Sigla {get;set;}

        public static List<SexoDTO> ListaSexo()
        {
            List<SexoDTO> lista = new List<SexoDTO>();
            lista.Add( new SexoDTO() { Sexo = "Masculino", Sigla = "M" });
            lista.Add( new SexoDTO() { Sexo = "Feminino", Sigla = "F" });
            return lista;
        }
    }
}
