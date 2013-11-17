using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Infraestrutura.Repositorios.Implementacao;


namespace Infraestrutura.Repositorios.Entidades.DTO
{
    public class PersonagemDTO
    {
        public virtual Int32 Id_person { get; set; }
        public virtual String Desc_Person { get; set; }

        public static IList<PersonagemDTO> ListaPerson()
        {
            GenericoRep<Personagens> repositorio = new GenericoRep<Personagens>();

            IEnumerable<Personagens> listaPerson = new List<Personagens>();
            listaPerson = repositorio.ObterTodos().OrderBy(x => x.Desc_person);

            IList<PersonagemDTO> lista = new List<PersonagemDTO>();
            lista.Insert(0, new PersonagemDTO
            {
                Id_person = 0,
                Desc_Person = "Selecione um Personagem"
            });

            foreach (Personagens personagem in listaPerson)
            {
                lista.Add(new PersonagemDTO
                {
                    Id_person = personagem.Id_person,
                    Desc_Person = personagem.Desc_person
                });
            }
            return lista;
        }
    }
}
