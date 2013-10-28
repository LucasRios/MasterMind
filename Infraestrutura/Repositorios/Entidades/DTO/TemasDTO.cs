using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Infraestrutura.Repositorios.Implementacao;

namespace Infraestrutura.Repositorios.Entidades.DTO
{
    public class TemasDTO
    {
        public virtual Int32 Id_tema { get; set; }
        public virtual String Desc_tema { get; set; }

        public static IList<TemasDTO> Lista()
        {
            GenericoRep<Temas> repositorio = new GenericoRep<Temas>();

            IEnumerable<Temas> listaTemas = new List<Temas>();
            listaTemas = repositorio.ObterTodos().OrderBy(x => x.Desc_tema);

            IList<TemasDTO> lista = new List<TemasDTO>();
            lista.Insert(0, new TemasDTO
            {
                Id_tema = 0,
                Desc_tema = "Selecione um Tema"
            });

            foreach (Temas tema in listaTemas)
            {
                lista.Add( new TemasDTO
                {
                    Id_tema = tema.Id_tema,
                    Desc_tema = tema.Desc_tema
                });
            }
            return lista;
        }
    }
}
