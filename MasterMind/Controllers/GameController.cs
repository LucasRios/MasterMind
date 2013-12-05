﻿using Infraestrutura.Repositorios.Entidades;
using Infraestrutura.Repositorios.Entidades.DTO;
using Infraestrutura.Repositorios.Implementacao;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebMatrix.WebData;
using System.Linq;
using System.Web;

namespace MasterMind.Controllers
{
    public class GameController : Controller
    {
        //
        // GET: /Game/

        public ActionResult Principal()
        {
            Usuario usuario = new Usuario();
            GenericoRep<Usuario> usu = new GenericoRep<Usuario>();

            usuario = usu.ObterPorId(WebSecurity.GetUserId(User.Identity.Name));

            return View(usuario);
        }

        [HttpGet]
        public ActionResult Prototipo()
        {
            return View(@"~/Views/Game/Partida.aspx");
        }

        [HttpGet]
        public ActionResult Partida(Int32 Id_Sala)
        {
            ///
            /// Partida - GAMES
            ///
            JogosRep jogoRep = new JogosRep();
            IList<Jogos> partida = jogoRep.ObterPorIdSala(Id_Sala);
            ViewBag.Partida = partida;

            /// Se não está definido a vez, será definido para o primeiro jogador que entrou na sala.
            Boolean vez = false;
            foreach (Jogos itemJogo in partida)
            {
                if(!vez)
                    vez = itemJogo.MinhaVez;
            }
            if (!vez)
            {
                Jogos primeiraJogada = partida.Where(x => x.SequenciaEntradaUsuarioSala == 1).FirstOrDefault();
                primeiraJogada.MinhaVez = true;
                jogoRep.Salvar(primeiraJogada);
            }
            ViewBag.JogadaDaVez = partida.Where(x => x.MinhaVez == true).FirstOrDefault();

            ///
            /// SALA 
            ///
            GenericoRep<Salas> salasRep = new GenericoRep<Salas>();
            Salas sala = salasRep.ObterPorId(Id_Sala);

            ///
            /// Pergunta Inicial
            /// 
            PerguntasRep perguntasRep = new PerguntasRep();
            Perguntas perguntaInicial = new Perguntas();
            if (sala.IdPerguntaAtual == 0)
            {
                Int32 temaInicial = partida.Where(x => x.MinhaVez).First().Tema.Id_tema;
                IList<Perguntas> perguntas = perguntasRep.ObterPerguntas(temaInicial);
                Random indicePergunta = new Random();
                perguntaInicial = perguntas[indicePergunta.Next(0, perguntas.Count - 1)];

                sala.IdPerguntaAtual = perguntaInicial.Id_Perg;
                sala.DataPergunta = DateTime.Now;
                salasRep.Salvar(sala);
            }
            else
            {
                perguntaInicial = perguntasRep.ObterPorId(sala.IdPerguntaAtual);
            }
            ViewBag.PerguntaInicial = perguntaInicial;
            ViewBag.Sala = sala;


            ///
            /// Atualiza hora da pergunta atual do jogador
            /// 
            int TempoRestante = 0;
            Jogos Jogador = partida.Where(x => x.Usuario.Id_user == WebSecurity.GetUserId(User.Identity.Name)).ElementAt(0);
            if (jogoRep.ObterPorIdSala(Id_Sala).Where(x => x.Usuario.Id_user == WebSecurity.GetUserId(User.Identity.Name)).FirstOrDefault().MinhaVez)
            {
                if (Jogador.PerguntaAtualFeitaEm == null)
                    Jogador.PerguntaAtualFeitaEm = DateTime.Now;
                if (Jogador.DataEntradaSala == null)
                    Jogador.DataEntradaSala = DateTime.Now;

                TempoRestante = 30 - DateTime.Now.Subtract(DateTime.Parse(Jogador.PerguntaAtualFeitaEm.ToString())).Seconds;
                ViewBag.TempoRestante = "Tempo restante " + TempoRestante.ToString() + " segundos";

                if (TempoRestante <= 0)
                {
                    TempoRestante = 30;
                    Responder(-1, Id_Sala);
                    return Partida(Id_Sala);
                }

            }
            else
            {
                Jogador.PerguntaAtualFeitaEm = null;
                ViewBag.TempoRestante = "O jogador tem 30 seg. para responder.";
            }

            jogoRep.Salvar(Jogador);

            ViewBag.Jogador = partida.Where(x => x.Usuario.Id_user == WebSecurity.GetUserId(User.Identity.Name)).FirstOrDefault();

            return View(@"~/Views/Game/Partida.cshtml");
        }

        [HttpGet]
        public JsonResult ObterStatusTabuleiro(Int32 Id_Sala)
        {
            Int32 layoutTabuleiro = 1;

            JogosRep jogoRep = new JogosRep();
            IList<Jogos> partida = jogoRep.ObterPorIdSala(Id_Sala);

            TrilhasTabuleiroRep trilhasRep = new TrilhasTabuleiroRep();
            List<StatusPartidaTabuleiroDTO> statusPartida = new List<StatusPartidaTabuleiroDTO>();

            foreach (Jogos item in partida)
            {
                TrilhasTabuleiro trilha = trilhasRep.ObterTrilhas(layoutTabuleiro, (int)item.SequenciaEntradaUsuarioSala, item.Acertos+1).FirstOrDefault();
                StatusPartidaTabuleiroDTO status = new StatusPartidaTabuleiroDTO();
                status.Id_user = item.Usuario.Id_user;
                status.Linha = trilha.Linha;
                status.Coluna = trilha.Coluna;
                status.CorPeca = (int)item.SequenciaEntradaUsuarioSala;
                statusPartida.Add(status);
            }

            var vm = new { statusTabuleiro = statusPartida };
            return Json(vm, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Ranking_top()
        {
            GenericoRep<Ranking> repositorio = new GenericoRep<Ranking>();
            IEnumerable<Ranking> ranking = repositorio.ObterTodos();

            ranking = ranking.OrderByDescending(c => c.qtde_partidas_ganhas).ThenByDescending(c => c.qtde_certas).ThenBy(c => c.qtde_erradas).ToList();

            List<Ranking> aux = new List<Ranking>();

            if (ranking != null)
            {
                for (var i = 0; i <= 2 && i<=ranking.Count()-1; i++)
                {
                   aux.Add(ranking.ElementAt(i));
                }
                ViewBag.achouRanking = false;
                for (var i = 0; i <= ranking.Count() - 1; i++)
                {
                    if (ranking.ElementAt(i).Id_User.Id_user == WebSecurity.GetUserId(User.Identity.Name))
                    {
                        ViewBag.achouRanking = true;
                        ranking.ElementAt(i).Id_Ranking = i + 1;
                        aux.Add(ranking.ElementAt(i));
                    }
                }
            }
            return View(aux);
        }

        public ActionResult Ranking()
        {
            GenericoRep<Ranking> repositorio = new GenericoRep<Ranking>();
            IEnumerable<Ranking> ranking = repositorio.ObterTodos();
            ranking = ranking.OrderByDescending(c => c.qtde_partidas_ganhas).ThenByDescending(c => c.qtde_certas).ThenBy(c => c.qtde_erradas).ToList();
            return View(ranking);
        }

        public JsonResult ProximaPergunta(Int32 Id_Sala)
        {
            JsonResult json = new JsonResult();

            ///
            /// Partida - GAMES
            ///
            JogosRep jogoRep = new JogosRep();
            IList<Jogos> partida = jogoRep.ObterPorIdSala(Id_Sala);
            ViewBag.Partida = partida;

            ///
            /// SALA 
            ///
            GenericoRep<Salas> salasRep = new GenericoRep<Salas>();
            Salas sala = salasRep.ObterPorId(Id_Sala);

            /// Pergunta
            /// 
            PerguntasRep perguntasRep = new PerguntasRep();
            Perguntas proximaPergunta = new Perguntas();

            Int32 temaDaVez = partida.Where(x => x.MinhaVez == true).First().Tema.Id_tema;
            IList<Perguntas> perguntas = perguntasRep.ObterPerguntas(temaDaVez);
            Random indicePergunta = new Random();
            proximaPergunta = perguntas[indicePergunta.Next(0, perguntas.Count - 1)];

            sala.IdPerguntaAtual = proximaPergunta.Id_Perg;
            sala.DataPergunta = DateTime.Now;
            salasRep.Salvar(sala);

            var vm = new { pergunta = proximaPergunta };

            json.Data = vm;
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return json;
        }

        public JsonResult Responder(Int32 IdResposta, Int32 IdSala)
        {
            JsonResult json = new JsonResult();

            SalasRep salaRep = new SalasRep();
            Salas sala = salaRep.ObterPorId(IdSala);
            sala.DataResposta = DateTime.Now;
            sala.IdPerguntaAtual = 0;
            salaRep.Salvar(sala);

            Boolean opcaoCerta = false;
            if (IdResposta != -1) // o parâmetro vem -1 quando o usuário deixa estourar o tempo para responder
            {
                GenericoRep<Respostas> respostaRep = new GenericoRep<Respostas>();
                Respostas resposta = respostaRep.ObterPorId(IdResposta);
                opcaoCerta = resposta.OpcaoCerta;
            }
            else opcaoCerta = false; 

            Boolean ganhou = atualiza_acerto_erro(opcaoCerta, IdSala);
            atualiza_ranking(opcaoCerta, ganhou);

            var vm = new { opcaoCerta = opcaoCerta, ganhou = ganhou };
            json.Data = vm;
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return json;
        }

        private void atualiza_ranking(Boolean opcaoCerta, Boolean partidaGanha = false)
        {
            GenericoRep<Ranking> rankingRep = new GenericoRep<Ranking>();
            IEnumerable<Ranking> rList = rankingRep.ObterTodos().Where(x => x.Id_User.Id_user == WebSecurity.GetUserId(User.Identity.Name));

            Ranking ranking = new Ranking();

            if (rList.Count() > 0)
                ranking = rList.ElementAt(0);
            else
            {
                GenericoRep<Usuario> UsuRep = new GenericoRep<Usuario>();
                Usuario usu = new Usuario();
                usu = UsuRep.ObterPorId(WebSecurity.GetUserId(User.Identity.Name));
                ranking.Id_User = usu;
            }

            if (opcaoCerta) ranking.qtde_certas = (ranking.qtde_certas + 1);
            else ranking.qtde_erradas = (ranking.qtde_erradas + 1);

            ranking.qtde_respostas = ranking.qtde_respostas + 1;

            if (partidaGanha) ranking.qtde_partidas_ganhas = ranking.qtde_partidas_ganhas + 1;

            rankingRep.Salvar(ranking);

        }           
        private Boolean atualiza_acerto_erro(Boolean opcaoCerta, Int32 IdSala)
        {
            JogosRep JogoRep = new JogosRep();
            Jogos jogador = JogoRep.ObterPorIdSala(IdSala).Where(x => x.Usuario.Id_user == WebSecurity.GetUserId(User.Identity.Name)).ElementAt(0);

            if (opcaoCerta)
            {
                jogador.Acertos = jogador.Acertos + 1;
            }
            else
            {
                jogador.Erros = jogador.Erros + 1;
                jogador.MinhaVez = false;

                Jogos proximo = JogoRep.ObterPorIdSala(IdSala).Where(x => x.SequenciaEntradaUsuarioSala == jogador.SequenciaEntradaUsuarioSala + 1).FirstOrDefault();
                if (proximo == null)
                {
                    /// Proxima rodada.
                    proximo = JogoRep.ObterPorIdSala(IdSala).Where(x => x.SequenciaEntradaUsuarioSala == 1).FirstOrDefault();
                }
                proximo.MinhaVez = true;
                JogoRep.Salvar(proximo);
            }

            jogador.DataUltimaResposta = DateTime.Now;
            JogoRep.Salvar(jogador);

            Int32 respostaFinal = 21;
            return jogador.Acertos == respostaFinal;
        }
        private void atualiza_nivel_personagem()
        {
            GenericoRep<Ranking> rankingRep = new GenericoRep<Ranking>();
            Ranking ranking = rankingRep.ObterTodos().Where(x => x.Id_User.Id_user == WebSecurity.GetUserId(User.Identity.Name)).ElementAt(0);

            GenericoRep<Usuario> UsuRep = new GenericoRep<Usuario>();
            Usuario usuario = UsuRep.ObterTodos().Where(x => x.Id_user == WebSecurity.GetUserId(User.Identity.Name)).ElementAt(0);

            if (usuario.Personagem.Nivel < (int)(ranking.qtde_partidas_ganhas / 2))
            {
                GenericoRep<Personagens> PerRep = new GenericoRep<Personagens>();
                IEnumerable<Personagens> lPersonagem = PerRep.ObterTodos().Where(x => x.Tema.Id_tema == usuario.Personagem.Tema.Id_tema);
                Personagens Personagem = lPersonagem.Where(x => x.Nivel == (int)(ranking.qtde_partidas_ganhas / 2)).ElementAt(0);
                usuario.Personagem = Personagem;

                UsuRep.Salvar(usuario);
            }

              
        }
    }
}
