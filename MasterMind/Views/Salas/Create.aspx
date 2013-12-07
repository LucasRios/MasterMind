<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Principal.Master" Inherits="System.Web.Mvc.ViewPage<Infraestrutura.Repositorios.Entidades.Salas>" %>

<asp:Content ID="aboutContent" ContentPlaceHolderID="PrincipalMiddle" runat="server">
    <% using (Html.BeginForm(new { ReturnUrl = ViewBag.ReturnUrl }))
       { %>
    <%: Html.AntiForgeryToken() %>
    <%: Html.ValidationSummary(true) %>
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <script src="../../Scripts/js/jquery.dropdown.js"></script>
    <fieldset>
        <legend>Create</legend>
        <div class="editor-field">
             <% Html.EnableClientValidation(); %>
            <%: Html.HiddenFor(model => model.Perfil, new { @Value = "2"})%>
            <h1>Crie sua propria Sala</h1>
        </div>
        <table>
            <tr>
                <td colspan="2">
                    <table id="tbCreate">
            <tr>
                <td>
                    <div class="editor-label">
                        <%: @Html.LabelFor(model => model.Sala)%>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%:   @Html.TextBoxFor(model => model.Sala, new  { @class="txtMedium" })%>
                        <%:   @Html.ValidationMessageFor(model => model.Sala)%>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="editor-label">
                        <%:    @Html.LabelFor(model => model.Perfil)%>
                    </div>
                </td>
                <td style="text-align: left;">
                    <div>
                        <input type="radio" name="beds" value="1" checked="checked" style="margin-right: 0; width: 30px" /><asp:Label ID="Label23" runat="server" Font-Bold="True" Width="80%" Style="text-align: left;">Privado</asp:Label>
                    </div>
                </td>
            </tr>
            <tr >
                <td style="width:250px;">
                    <div class="editor-label"><%:  @Html.LabelFor(model => model.Niveis.descricao)%></div>
                </td>
                <td>
                    <div class="container" style="width:120px; height:40px; float: left;  ">
                        <section class="main clearfix" style="float: left; ">

                            <div class="fleft" style=" float: left; margin-top:-10px; margin-left:-35px;  margin-right: 10px;  ">
                                <select id="tpNivel" name="cd-dropdown" class="cd-select" ">
                                    <% foreach (var item in ViewBag.ListaNiveis)
                                       { %>
                                    <option
                                        <% if (item.Id_Nivel == 0)
                                           {%>
                                        value="-1"
                                        selected
                                        <%}
                                           else
                                           {%>
                                        value="<%:  item.Id_Nivel %>"
                                        <%} %>>
                                        <%:  item.descricao %>
                                    </option>
                                    <%  }  %>
                                </select>
                            </div>



                        </section>



                    </div>
                    <%--<%:  @Html.ValidationMessageFor(model => model.Niveis.Id_Nivel)%>--%>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="editor-label">
                        <%:  @Html.LabelFor(model => model.Senha)%>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%:  @Html.TextBoxFor(model => model.Senha, new  { @class="txtMedium" })%>
                        <%:  @Html.ValidationMessageFor(model => model.Senha)%>
                    </div>
                </td>
            </tr>
</table>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <div>
                        <input type="button" id="btnCriar" class="btn btn-info" value="Acessar" />
                        <%--<input type="submit" class="btn btn-info" value="Acessar" />--%>
                    </div>
                </td>
            </tr>
        </table>
    </fieldset>
    <% } %>


    <script type="text/javascript">
        $(document).ready(function () {

            $(function () {

                $('#tpNivel').dropdown({
                    stack: false,
                    gutter: 5
                });

            });






            $("#btnCriar").click(function (e) {
                var dropValue = document.getElementsByName("cd-dropdown");
                console.log($("#Sala"));
                var ai = {
                    DataPergunta: null,
                    DataResposta: null,
                    Desc_perfil: null,
                    Id_Sala: null,
                    Id_Usuario: null,
                    IdPerguntaAtual: null,
                    Niveis: { Id_Nivel: 1, descricao: null },
                    Perfil: 2,
                    qtde_usu: 0,
                    Sala: $("#Sala")[0].value,
                    Senha: $("#Senha")[0].value,
                    Usuario: null
                };

                var dataSender = JSON.parse(JSON.stringify(ai));
                console.log(dataSender);
                $.ajax({
                    url: 'Create',
                    type: 'POST',
                    data: JSON.stringify(ai),
                    contentType: 'application/json',
                    dataType: 'json',
                    success: function (e) {
                        console.log(e);
                    },
                    error: function (e) {
                        //alert("error");
                        console.log(e);
                    }
                });

            });

            function verificaCampos() {
                $("#Sala")[0].value
            }
        });
    </script>
</asp:Content>



