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
    $.post("Responder", { IdResposta: $(".alternativas :radio:checked").val() })
    .success(function (response) {
        if (response.opcaoCerta) {
            $("#divCerto").css('display', 'inline');
            $("#divErrado").css('display', 'none');
        }
        else {
            $("#divErrado").css('display', 'inline');
            $("#divCerto").css('display', 'none');
        }
    });
};

