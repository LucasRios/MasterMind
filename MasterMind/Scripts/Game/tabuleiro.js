var tam_celula = (12 + 0) * 4;
var pathPecas = "../Images/svg/";

var objJogador = {
    Id_user: 0,
    Id_nome: 'jogador1',
    linha: 0,
    coluna: 5,
    tema: 'tema1',
    cor: 'verde'
}

var posicaoPecas = [];

$(function () {
    cria_tabuleiro(5, 3);
    coloca_peca(posicaoPecas[0].linha, posicaoPecas[0].coluna, pathPecas + posicaoPecas[0].cor, 0)
    coloca_peca(posicaoPecas[1].linha, posicaoPecas[1].coluna, pathPecas + posicaoPecas[1].cor, 0)
    coloca_peca(posicaoPecas[2].linha, posicaoPecas[2].coluna, pathPecas + posicaoPecas[2].cor, 0)
});


function cria_tabuleiro(casas, largura_fileira) {
    var varicao_cor = Math.ceil(255 / ((2 * casas) + largura_fileira));
    $("#tabuleiro").empty();
    for (i = 0; i < ((2 * casas) + largura_fileira) ; i++) {
        $("#tabuleiro").append("<tr id='linha_" + i + "'></tr>");
        for (j = 0; j < ((2 * casas) + largura_fileira) ; j++) {
            if ((((j >= casas && j < casas + largura_fileira) || (i >= casas && i < casas + largura_fileira))) || (((j >= casas - 1 && j < casas + largura_fileira + 1) && (i >= casas - 1 && i < casas + largura_fileira + 1)))) {
                if (!((j >= casas && j < casas + largura_fileira) && (i >= casas && i < casas + largura_fileira))) {
                    $("#linha_" + i).append("<td class='celula-ativa' id='celula_" + i + "_" + j + "' width='" + tam_celula + "' height='" + tam_celula + "' style='background-color:rgb(0," + i * varicao_cor + "," + j * varicao_cor + ");clear:both; '></td>");
                }

                else {
                    $("#linha_" + i).append("<td class='celula-inativa' id='celula_" + i + "_" + j + "' width='" + tam_celula + "' height='" + tam_celula + "' ></td>");
                }

            }
            else {
                $("#linha_" + i).append("<td class='celula-inativa' id='celula_" + i + "_" + j + "' width='" + tam_celula + "' height='" + tam_celula + "' ></td>");
            }
        }
    }
}

function coloca_peca(linha, coluna, cor, nivel) {
    $("#celula_" + linha + "_" + coluna).append("<img src='" + cor + ".svg' width='" + (tam_celula - (nivel * 4)) + "' height='" + (tam_celula - (nivel * 4)) + "' style='position:relative;float:left;top:" + Math.ceil(tam_celula / 2) + "px;margin-top:-" + (tam_celula - (nivel * 2)) + "px; margin-left:" + (nivel * 2) + "px; z-indez:" + (100 - nivel) + "; '/>");
}

// Testes
// Testes
// Testes
// Testes

function teste() {
    frame_tabuleiro.cria_tabuleiro(5, 3);
    for (i = 0; i < 4; i++) {
        frame_tabuleiro.coloca_peca(7, 9, 'verde', (i * 3) + 1);
        frame_tabuleiro.coloca_peca(7, 9, 'vermelho', (i * 3) + 2);
        frame_tabuleiro.coloca_peca(7, 9, 'amarelo', (i * 3) + 3);
    }
    frame_tabuleiro.coloca_peca(7, 10, 'vermelho', 6);
    frame_tabuleiro.coloca_peca(7, 11, 'amarelo', 0);
}
function cria_tab() {
    frame_tabuleiro.cria_tabuleiro(Math.ceil(criacao_tabuleiro.casas.value), Math.ceil(criacao_tabuleiro.filas.value));
}
function empilha() {
    var casas = Math.ceil(criacao_tabuleiro.casas.value);
    for (i = 0; i < 4; i++) {
        frame_tabuleiro.coloca_peca(casas - 1, casas - 1, 'verde', (i * 3) + 1);
        frame_tabuleiro.coloca_peca(casas - 1, casas - 1, 'vermelho', (i * 3) + 2);
        frame_tabuleiro.coloca_peca(casas - 1, casas - 1, 'amarelo', (i * 3) + 3);
    }

}

function poe_peca() {
    col = Math.ceil(add_peca.col.value);
    lin = Math.ceil(add_peca.lin.value);
    cor = add_peca.cor.value;
    nivel = Math.ceil(add_peca.nivel.value);
    frame_tabuleiro.coloca_peca(lin, col, cor, nivel);
}
