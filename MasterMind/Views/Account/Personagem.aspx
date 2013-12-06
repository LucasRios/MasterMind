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
            <h1>Escolha seu personagem favorito</h1>
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
                                    <% if (!string.IsNullOrEmpty(ViewBag.SelectedPerson))%>
                                    <% {%>
                                    <img src="<%: ViewBag.SelectedPerson %>" height="100" width="100" />
                                    <br />
                                    <h6><%: ViewBag.NameSelectedPerson %> </h6>
                                    <% }
                                       else
                                       {%>
                                    <img src="~/Images/usu.png" height="100" width="100" />
                                    <%} %>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr style="text-align: center; align-content: center;">
                    <td style="text-align: center; align-content: center;">
                        <%:  @Html.DropDownListFor(u => u.Personagem.Id_person, new SelectList(ViewBag.ListaPerson, "Id_person", "Desc_person"), new { @class = "dropdownlist", onchange= "document.location.href = '/Account/Personagem?Id_Person=' + this.options[this.selectedIndex].value;" })%>
                        <%: Html.HiddenFor(u => u.Personagem.Desc_person)%>
                        <%:  @Html.ValidationMessageFor(u => u.Personagem.Id_person)%>
                    </td>
                </tr>
                <tr style="text-align: center; align-content: center;">
                    <td colspan="2" style="text-align: center">
                        <div>
                            <input type="submit" class="btn btn-info" value="Salvar" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </body>
    </html>
    <% } %>
</asp:Content>


