$(function () {


});

function Responder() {
    $.post("Responder", { IdResposta: $(".alternativas :radio:checked").val() })
    .success(function (response) {
        alert(response.opcaoCerta);
    });
};
