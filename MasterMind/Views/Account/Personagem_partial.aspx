<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Principal.Master" Inherits="System.Web.Mvc.ViewPage<Infraestrutura.Repositorios.Entidades.Usuario>" %>

<asp:Content ID="aboutContent" ContentPlaceHolderID="PrincipalMiddle" runat="server">


    <% using (Html.BeginForm(new { ReturnUrl = ViewBag.ReturnUrl }))
       { %>
    <%: Html.AntiForgeryToken() %>
    <%: Html.ValidationSummary(true) %>

 
        <link rel="shortcut icon" href="../favicon.ico">
        <link href="~/Content/Site.css" rel="stylesheet" />
        <link href="~/Styles/style1.css" rel="stylesheet" />
        <link href="~/Styles/bootstrap-responsive.min.css" rel="stylesheet" />
        <link href="~/Styles/bootstrap.min.css" rel="stylesheet" />
   
        <div style="align-content: center">
            <h1>Escolha seu personagem favorito</h1>
        </div>
        <div style="position: relative; align-content: center; text-align: center">
            <table style="text-align: center">
                <tr style="text-align: center">
                    <td style="text-align: center">
                        <div class="editor-label"><%:  @Html.LabelFor(model => model.Personagem.Desc_person)%></div>
                        <%: Html.HiddenFor(model => model.auxId_person)%>
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td style="text-align: center">
                        <table>
                            <tr>
                                <td>
                                    <h6>Personagem Atual</h6>
                                    <div><% @Html.RenderAction("Personagem_partial_atual", "Account"); %></div>
                                </td>
                                <td style="vertical-align: central">
                                    <img src="../Images/seta_dir.png" height="50" width="50" />
                                </td>
                                <td style="vertical-align: top">
                                    <h6>Novo Personagem</h6>
                                    <% if (!string.IsNullOrEmpty(ViewBag.SelectedPerson))%>
                                    <% {%>
                                    <img src="<%: ViewBag.SelectedPerson %>" class="imgPerfil" />
                                    <br />
                                    <h6><%: ViewBag.NameSelectedPerson %> </h6>
                                    <% }
                                       else
                                       {%>
                                    <img src="../Images/usu.png" class="imgPerfil" />
                                    <%} %>
                                </td>
                            </tr>
                        </table>
                        <h3>Nível: <%: @Html.ValueFor(model => model.Personagem.Nivel) %></h3>
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td style="text-align: center">
                         <div class="divSelect" style="margin-left:95px;" >
                        <%:  @Html.DropDownListFor(u => u.Personagem.Id_person, new SelectList(ViewBag.ListaPerson, "Id_person", "Desc_person"), new { @class = "dropdownlist", onchange= "window.location.href = '/MasterMind/Account/Personagem_partial?Id_Person=' + this.options[this.selectedIndex].value;" })%>                        
                             </div>
                        <%: Html.HiddenFor(u => u.Personagem.Desc_person)%>
                        <%:  @Html.ValidationMessageFor(u => u.Personagem.Id_person)%>
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td colspan="2" style="text-align: center">
                        <div>
                            <input type="submit" class="btn btn-info" value="Salvar" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
  
    <% } %>
</asp:Content>


