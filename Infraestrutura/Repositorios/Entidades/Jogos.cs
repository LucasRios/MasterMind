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

        [Display(Name = "Senha de Acesso")]
        [StringLength(25, ErrorMessage = "Máximo 25 caracteres.")]
        public virtual String Senha { get; set; }

        public virtual Temas Tema { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Salas Sala { get; set; }
        
        public virtual Int32? CorPeca { get; set; }
        public virtual Int32? SequenciaEntradaUsuarioSala { get; set; }
        public virtual Int32? PosLinhaInicial { get; set; }
        public virtual Int32? PosColunaInicial { get; set; }
        public virtual Int32? PosLinhaAtual { get; set; }
        public virtual Int32? PosColunaAtual { get; set; }
        public virtual DateTime? DataEntradaSala { get; set; }
        public virtual DateTime? DataUltimaResposta { get; set; }
        public virtual DateTime? DataUltimoAcerto { get; set; }
        public virtual DateTime? PerguntaAtualFeitaEm { get; set; }
        public virtual Int32 Acertos { get; set; }
        public virtual Int32 Erros { get; set; }
        public virtual Int32? finalizado { get; set; }
        public virtual Boolean MinhaVez { get; set; }
        public virtual String TrilhaTemas { get; set; }
    }
}
