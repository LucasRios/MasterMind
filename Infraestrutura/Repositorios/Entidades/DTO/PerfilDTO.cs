using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Infraestrutura.Repositorios.Implementacao;


namespace Infraestrutura.Repositorios.Entidades.DTO
{
    public class PerfilDTO
    {
        public virtual Int32 Id_Perfil { get; set; }
        public virtual String descricao { get; set; }

        public static IList<PerfilDTO> ListaPerfil()
        {
            GenericoRep<Perfil> repositorio = new GenericoRep<Perfil>();

            IEnumerable<Perfil> listaPerfil = new List<Perfil>();
            listaPerfil = repositorio.ObterTodos().OrderBy(x => x.descricao);

            IList<PerfilDTO> lista = new List<PerfilDTO>();
            lista.Insert(0, new PerfilDTO
            {
                Id_Perfil = 0,
                descricao = "Selecione um Perfil"
            });

            foreach (Perfil perfil in listaPerfil)
            {
                lista.Add( new PerfilDTO
                {
                    Id_Perfil = perfil.Id_Perfil,
                    descricao = perfil.descricao
                });
            }
            return lista;
        }
    }
}
