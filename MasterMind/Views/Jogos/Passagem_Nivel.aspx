<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Infraestrutura.Repositorios.Entidades.Usuario>" %>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">


    <% using (Html.BeginForm(new { ReturnUrl = ViewBag.ReturnUrl }))
       { %>
    <%: Html.AntiForgeryToken() %>
    <%: Html.ValidationSummary(true) %>

    <html>
    <head>
        <link rel="shortcut icon" href="../favicon.ico">
        <link href="~/Content/Site.css" rel="stylesheet" />
        <link href="~/Styles/style1.css" rel="stylesheet" />
        <link href="~/Styles/bootstrap-responsive.min.css" rel="stylesheet" />
        <link href="~/Styles/bootstrap.min.css" rel="stylesheet" />
    </head>
    <body id="body_perso" style="text-align: center; align-content: center;">
        <div style="align-content: center">
            <h1>Parabéns! Com esta vitória seu personagem evoluiu!!</h1>
        </div>
        <div style="align-content: center; text-align: center">
            <table style="text-align: center; align-content: center; min-width: 100%">
                <tr style="text-align: center; align-content: center;">
                    <td style="text-align: center; align-content: center;">
                        <div class="editor-label"><%:  @Html.LabelFor(model => model.Personagem.Desc_person)%></div>
                        <%: Html.HiddenFor(model => model.auxId_person)%>
                    </td>
                </tr>
                <tr style="text-align: center; align-content: center;">
                    <td style="text-align: center; align-content: center;">
                        <table style="min-height:100%;width:100%; text-align: center; align-content: center;">
                            <tr style="text-align: center; align-content: center;">
                                <td style="vertical-align: top; text-align: center; align-content: center;padding-left:20px">
                                    <h6>Novo Personagem</h6>
                                    <% if (!string.IsNullOrEmpty(Html.ValueFor(model => model.Personagem.Imagem).ToString()))%>
                                    <% {%>
                                    <img src="<%: @Html.ValueFor(model => model.Personagem.Imagem) %>" height="100" width="100" />
                                    <br />
                                    <h6><%: @Html.ValueFor(model => model.Personagem.Desc_person) %> </h6>
                                    <% }
                                       else
                                       {%>
                                    <img src="~/Images/usu.png" height="100" width="100" />
                                    <%} %>
                                </td>
                            </tr>
                        </table>
                        <h3>Nível: <%: @Html.ValueFor(model => model.Personagem.Nivel) %></h3>
                    </td>
                </tr>
                <tr style="text-align: center; align-content: center;">
                    <td colspan="2" style="text-align: center">
                        <div>
                            <input type="button" class="btn btn-info" value="Continuar" onclick="window.location.href='<%: @Url.Action("List", "Salas")%>'" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </body>
    </html>
    <% } %>
</asp:Content>


