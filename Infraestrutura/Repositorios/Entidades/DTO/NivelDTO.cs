using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Infraestrutura.Repositorios.Implementacao;


namespace Infraestrutura.Repositorios.Entidades.DTO
{
    public class NivelDTO
    {
        public virtual Int32 Id_Nivel { get; set; }
        public virtual String descricao { get; set; }

        public static IList<NivelDTO> ListaNivel()
        {
            GenericoRep<Nivel> repositorio = new GenericoRep<Nivel>();

            IEnumerable<Nivel> listaNivel = new List<Nivel>();
            listaNivel = repositorio.ObterTodos().OrderBy(x => x.descricao);

            IList<NivelDTO> lista = new List<NivelDTO>();
            lista.Insert(0, new NivelDTO
            {
                Id_Nivel = 0,
                descricao = "Selecione um Nivel"
            });

            foreach (Nivel nivel in listaNivel)
            {
                lista.Add( new NivelDTO
                {
                    Id_Nivel = nivel.Id_Nivel,
                    descricao = nivel.descricao
                });
            }
            return lista;
        }
    }
}
