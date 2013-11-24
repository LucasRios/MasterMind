using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Infraestrutura.Repositorios.Entidades.Map
{
    public class JogosMap: ClassMap<Jogos>
    {
        public JogosMap()
        {
            Table("Jogos");
            Id(x => x.Id_jogo, "Id_jogo").GeneratedBy.Identity();
            References(x => x.Tema).Column("Id_tema").Cascade.None().LazyLoad();
            References(x => x.Usuario).Column("Id_user").Cascade.None().LazyLoad();
            References(x => x.Sala).Column("Id_sala").Cascade.None().LazyLoad();

            Map(x=>x.CorPeca);
            Map(x=>x.SequenciaEntradaUsuarioSala);
            Map(x=>x.PosLinhaInicial);
            Map(x=>x.PosColunaInicial);
            Map(x=>x.PosLinhaAtual);
            Map(x=>x.PosColunaAtual);
            Map(x=>x.DataEntradaSala);
            Map(x=>x.DataUltimaResposta);
            Map(x=>x.PerguntaAtualFeitaEm);
            Map(x=>x.Acertos);
            Map(x => x.Erros);
        }
    }
}
