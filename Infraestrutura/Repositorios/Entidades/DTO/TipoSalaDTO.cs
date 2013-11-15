using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Infraestrutura.Repositorios.Implementacao;


namespace Infraestrutura.Repositorios.Entidades.DTO
{
    public class TipoSalaDTO
    {
        public virtual Int32 Id_TPSala { get; set; }
        public virtual String descricao { get; set; }

        public static IList<TipoSalaDTO> ListaTipoSala()
        {
            IList<TipoSalaDTO> lista = new List<TipoSalaDTO>();
            lista.Insert(0, new TipoSalaDTO
            {
                Id_TPSala = 0,
                descricao = "Selecione um Perfil"
            });

            lista.Insert(0, new TipoSalaDTO
            {
                Id_TPSala = 1,
                descricao = "Pública"
            });

            lista.Insert(0, new TipoSalaDTO
            {
                Id_TPSala = 2,
                descricao = "Privada"
            });

            return lista;
        }
    }
}
