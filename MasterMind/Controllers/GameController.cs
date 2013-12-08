using Infraestrutura.Repositorios.Entidades;
using Infraestrutura.Repositorios.Entidades.DTO;
using Infraestrutura.Repositorios.Implementacao;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebMatrix.WebData;
using System.Linq;
using System.Web;
using System.Threading;

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

        public void Partida_finalizada(int id_jogo)
        {
            JogosRep genJogo = new JogosRep();
            Jogos jogo = genJogo.ObterPorId(id_jogo);
            if (jogo.finalizado == null) jogo.finalizado = 0;

            if (genJogo.ObterPorIdSala(jogo.Sala.Id_Sala).Where(x => x.Acertos == 21).Count() > 0)
            {
                if ((jogo.finalizado == 0) && (genJogo.ObterPorIdSala(jogo.Sala.Id_Sala).Where(x => x.Acertos == 21).FirstOrDefault().Usuario.Id_user == WebSecurity.GetUserId(User.Identity.Name)))
                {
                    atualiza_ranking(true, true);
                }
                
                jogo.finalizado = 1 + jogo.finalizado;
                genJogo.Salvar(jogo);
            }
            
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
            /// Define os temas dos jogo
            /// 
            if ( string.IsNullOrEmpty(partida.Where(x => x.Usuario.Id_user == WebSecurity.GetUserId(User.Identity.Name)).FirstOrDefault().TrilhaTemas))
                partida.Where(x => x.Usuario.Id_user == WebSecurity.GetUserId(User.Identity.Name)).FirstOrDefault().TrilhaTemas = Trilha_temas(partida.Where(x => x.Usuario.Id_user == WebSecurity.GetUserId(User.Identity.Name)).FirstOrDefault().Id_jogo, 21);
            ///
            /// SALA 
            ///
            GenericoRep<Salas> salasRep = new GenericoRep<Salas>();
            Salas sala = salasRep.ObterPorId(Id_Sala);

            ///
            /// Tema Atual da sala
            ///
            Int32 tema_atual = partida.Where(x => x.Usuario.Id_user == WebSecurity.GetUserId(User.Identity.Name)).FirstOrDefault().Tema.Id_tema;
            var debug1 = partida.Where(x => x.MinhaVez).First();

            if (!string.IsNullOrEmpty(partida.Where(x => x.MinhaVez).First().TrilhaTemas))
            {
                tema_atual = recupera_tema(partida.Where(x => x.MinhaVez).First().Id_jogo, partida.Where(x => x.MinhaVez).First().TrilhaTemas);
                GenericoRep<Temas> gentemas = new GenericoRep<Temas>();
                ViewBag.TemaAtual = gentemas.ObterPorId(tema_atual).Desc_tema;

            }
            else
            {
                ViewBag.TemaAtual = "";  
            }
            ///
            /// Pergunta Inicial
            /// 
            PerguntasRep perguntasRep = new PerguntasRep();
            Perguntas perguntaInicial = new Perguntas();
            if (sala.IdPerguntaAtual == 0)
            {                
                IList<Perguntas> perguntas = perguntasRep.ObterPerguntas(tema_atual);
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
            TempoRestante = 30 - DateTime.Now.Subtract(DateTime.Parse(sala.DataPergunta.ToString())).Seconds;
            ViewBag.TempoRestante = "Tempo restante " + TempoRestante.ToString() + " segundos";

            if (TempoRestante <= 0)
            {
                TempoRestante = 30;
                Responder(-1, Id_Sala);
                return Partida(Id_Sala);
            }
           

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
                TrilhasTabuleiro trilha = trilhasRep.ObterTrilhas(layoutTabuleiro, (int)item.SequenciaEntradaUsuarioSala, item.Acertos + 1).FirstOrDefault();
                Int32 nivel = 0;
                try
                {
                    IList<Jogos> mesmaCasa = partida.Where(x =>
                            x.PosLinhaAtual == trilha.Linha
                        && x.PosColunaAtual == trilha.Coluna
                        //&& x.Usuario.Id_user != item.Usuario.Id_user
                    ).OrderBy(x => x.DataUltimoAcerto).ToList();

                    Int32 indiceMesmaCasa = 9 / mesmaCasa.Count;

                    nivel = mesmaCasa.IndexOf(item) * indiceMesmaCasa;
                }
                catch
                {
                    nivel = 0;
                }


                StatusPartidaTabuleiroDTO status = new StatusPartidaTabuleiroDTO();
                status.Id_user = item.Usuario.Id_user;
                status.Linha = trilha.Linha;
                status.Coluna = trilha.Coluna;
                status.CorPeca = (int)item.SequenciaEntradaUsuarioSala;
                status.Nivel = nivel;
                statusPartida.Add(status);
            }

            statusPartida = statusPartida.OrderBy(x => x.Linha).ThenBy(x => x.Coluna).ThenBy(x => x.Nivel).ToList();

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

            atualiza_ranking(opcaoCerta, false);

            JogosRep genjogo = new JogosRep();
            Partida_finalizada(genjogo.ObterPorIdSala(IdSala).Where(x => x.Usuario.Id_user == WebSecurity.GetUserId(User.Identity.Name)).FirstOrDefault().Id_jogo); 

            if (opcaoCerta) avanca_tema(IdSala);

            var vm = new { opcaoCerta = opcaoCerta, ganhou = ganhou };
            json.Data = vm;
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return json;
        }

        private Int32 recupera_tema(int id_Jogo, string trilha_temas)
        {
            GenericoRep<Jogos> genJogos = new GenericoRep<Jogos>();
            Jogos jogador = genJogos.ObterPorId(id_Jogo);

            List<String> arrayTemas = trilha_temas.Split(';').ToList<String>();
            Int32 prox_tema = 0;
            if (arrayTemas.Count() != 0)
                prox_tema =Convert.ToInt32(arrayTemas.FirstOrDefault());

            return prox_tema;
        }

        private void avanca_tema(int id_Sala)
        {
            JogosRep genJogos = new JogosRep();
            Jogos jogador = genJogos.ObterPorIdSala(id_Sala).Where(x => x.Usuario.Id_user == WebSecurity.GetUserId(User.Identity.Name)).FirstOrDefault();

            List<String> arrayTemas = jogador.TrilhaTemas.Split(';').ToList<String>();
            Int32 prox_tema = Convert.ToInt32(arrayTemas.FirstOrDefault());

            arrayTemas.RemoveAt(0);
            
            string trilha_temas = "";
            foreach (var x in arrayTemas)
            {
                trilha_temas = trilha_temas+ x.ToString()+";";
            }
            if (trilha_temas.Count() > 0) trilha_temas = trilha_temas.Remove(trilha_temas.Count() - 1);

            jogador.TrilhaTemas = trilha_temas;
            genJogos.Salvar(jogador);
            
        }


        private string Trilha_temas(Int32 Id_Jogo, int temas_restantes)
        { 
            GenericoRep<Jogos> genJogos = new GenericoRep<Jogos>();
            Jogos jogador = genJogos.ObterPorId(Id_Jogo);

            if ((temas_restantes >= 18) || (temas_restantes == 1)) //quatro primeiras casas, mesmo tema / última casa, mesmo tema
            {
                if (string.IsNullOrEmpty(jogador.TrilhaTemas)) jogador.TrilhaTemas = jogador.Tema.Id_tema.ToString();
                else jogador.TrilhaTemas = jogador.TrilhaTemas.ToString().Trim() + ";" + jogador.Tema.Id_tema;
                genJogos.Salvar(jogador);
                Trilha_temas(jogador.Id_jogo, temas_restantes - 1);
                jogador = genJogos.ObterPorId(Id_Jogo);
                return jogador.TrilhaTemas;
            }
            else if (temas_restantes != 0)// casas ao redor do tabuleiro
            { 
                Random indiceTema = new Random();
                GenericoRep<Temas> genTemas = new GenericoRep<Temas>();
                IEnumerable<Temas> lTemas = genTemas.ObterTodos();

                int id_prox_tema = jogador.Tema.Id_tema;
                while ((id_prox_tema == jogador.Tema.Id_tema) || (lTemas.Where(x => x.Id_tema == id_prox_tema).Count() == 0))
                {
                   id_prox_tema = indiceTema.Next(1,lTemas.Count() - 1); 
                }

                jogador.TrilhaTemas = jogador.TrilhaTemas.ToString().Trim() + ";" + id_prox_tema;
                genJogos.Salvar(jogador);
                Trilha_temas(jogador.Id_jogo, temas_restantes - 1);
                jogador = genJogos.ObterPorId(Id_Jogo);
                return jogador.TrilhaTemas;          
            }
            jogador = genJogos.ObterPorId(Id_Jogo);
            return jogador.TrilhaTemas; // temas restante == 0 ... começa a voltar a recursividade
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

            if (partidaGanha)
            { ranking.qtde_partidas_ganhas = ranking.qtde_partidas_ganhas + 1; }
            else
            {

                if (opcaoCerta) ranking.qtde_certas = (ranking.qtde_certas + 1);
                else ranking.qtde_erradas = (ranking.qtde_erradas + 1);

                ranking.qtde_respostas = ranking.qtde_respostas + 1;
            }

             

            rankingRep.Salvar(ranking);

        }           
        private Boolean atualiza_acerto_erro(Boolean opcaoCerta, Int32 IdSala)
        {
            JogosRep jogosRep = new JogosRep();
            Jogos meuJogo = jogosRep.ObterPorIdSala(IdSala).Where(x => x.Usuario.Id_user == WebSecurity.GetUserId(User.Identity.Name)).ElementAt(0);

            Int32 respostaFinal = 21;
            Boolean ganhou = false;

            IList<Jogos> pecasEmCima = new List<Jogos>();
            TrilhasTabuleiroRep trilhaRep = new TrilhasTabuleiroRep();
            Int32 layoutTabuleiro = 1;
 
            if (opcaoCerta)
            {
                meuJogo.Acertos = meuJogo.Acertos + 1;
                DateTime? dataUltimoAcertoAnterior = meuJogo.DataUltimoAcerto;
                meuJogo.DataUltimoAcerto = DateTime.Now;
                Thread.Sleep(1000);
 
                ganhou = meuJogo.Acertos == respostaFinal;
                if (opcaoCerta && !ganhou)
                {
                    pecasEmCima = jogosRep.ObterPorIdSala(IdSala)
                        .Where(x =>
                                x.Usuario.Id_user != meuJogo.Usuario.Id_user
                            && x.PosLinhaAtual == meuJogo.PosLinhaAtual
                            && x.PosColunaAtual == meuJogo.PosColunaAtual
                            && x.DataUltimoAcerto > dataUltimoAcertoAnterior
                            && x.Acertos < 20
                        ).OrderBy(x => x.DataUltimoAcerto)
                        .ToList();

                    foreach (Jogos jogoPecaDeCima in pecasEmCima)
                    {
                        jogoPecaDeCima.Acertos++;
                        jogoPecaDeCima.DataUltimoAcerto = DateTime.Now;

                        /// Alterar a posicao das peças que estão acima da atual.
                        TrilhasTabuleiro trilhaPecaDeCima = trilhaRep.ObterTrilhas(layoutTabuleiro, (int)jogoPecaDeCima.SequenciaEntradaUsuarioSala, jogoPecaDeCima.Acertos + 1).FirstOrDefault();
                        jogoPecaDeCima.PosLinhaAtual = trilhaPecaDeCima.Linha;
                        jogoPecaDeCima.PosColunaAtual = trilhaPecaDeCima.Coluna;

                        Thread.Sleep(1000);
                        jogosRep.Salvar(jogoPecaDeCima);
                    }
                }

                Int32 idTrilha = (int)meuJogo.SequenciaEntradaUsuarioSala;

                TrilhasTabuleiro trilha = trilhaRep.ObterTrilhas(layoutTabuleiro, idTrilha, meuJogo.Acertos+1).FirstOrDefault();

                meuJogo.PosLinhaAtual = trilha.Linha;
                meuJogo.PosColunaAtual = trilha.Coluna;
            }
            else
            {
                meuJogo.Erros = meuJogo.Erros + 1;
                meuJogo.MinhaVez = false;

                Jogos proximo = jogosRep.ObterPorIdSala(IdSala).Where(x => x.SequenciaEntradaUsuarioSala == meuJogo.SequenciaEntradaUsuarioSala + 1).FirstOrDefault();
                if (proximo == null)
                {
                    /// Proxima rodada.
                    proximo = jogosRep.ObterPorIdSala(IdSala).Where(x => x.SequenciaEntradaUsuarioSala == 1).FirstOrDefault();
                }
                proximo.MinhaVez = true;
                jogosRep.Salvar(proximo);
            }

            meuJogo.DataUltimaResposta = DateTime.Now;
            jogosRep.Salvar(meuJogo);

            return ganhou;
        }

    }
}
