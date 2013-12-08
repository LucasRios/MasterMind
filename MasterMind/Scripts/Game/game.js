$(function () {
    $(".alternativa-off").bind({
        click: function () {
            $(this).parent().children().children("label").removeClass("alternativa-on");
            $(this).children("label").removeClass("alternativa-off");
            $(this).children("label").addClass("alternativa-on");
        }
    });

});

function Responder() {
    $.ajaxSetup({ cache: false });
    $.post("Responder", { IdResposta: $(".alternativas :radio:checked").val(), IdSala: $("#hddId_Sala").val() })
    .success(function (response) {
        if (response.opcaoCerta) {
            $("#divCerto").css('display', 'inline');
            $("#divErrado").css('display', 'none');
            AtualizarTabuleiro_resp_certa();
            $("#divCartas").css('display', 'none');
            $("#divSeta").css('display', 'none');
            
        }
        else {
            $("#divErrado").css('display', 'inline');
            $("#divCerto").css('display', 'none');
            $("#divCartas").css('display', 'none');
            $("#divSeta").css('display', 'none');
        }
    });
};

