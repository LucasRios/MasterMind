<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Infraestrutura.Repositorios.Entidades.Usuario>" %>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">

    <% using (Html.BeginForm(new { ReturnUrl = ViewBag.ReturnUrl }))
       { %>
    <%: Html.AntiForgeryToken() %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <div>
            <h1>Escolha seu personagem favorito</h1>
        </div>
        <div style="text-align: center">
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
                                        <img src="<%: ViewBag.UserPerson %>" height="100" width="100" />
                                        <br /><h6><%: @Html.ValueFor(model => model.Personagem.Desc_person) %></h6>
                                </td>
                                <td style="vertical-align: central">
                                        <img src="../../Images/seta_dir.png" height="50" width="50" />  
                                </td>
                                <td style="vertical-align: top">                                    
                                        <h6>Novo Personagem</h6>
                                        <% if (!string.IsNullOrEmpty(ViewBag.SelectedPerson))%>
                                        <% {%>
                                        <img src="<%: ViewBag.SelectedPerson %>" height="100" width="100" />
                                        <% }
                                           else
                                           {%>
                                        <img src="../../Images/usu.png" height="100" width="100" />
                                        <% }%>
                                       <br /> <h6><%: ViewBag.NameSelectedPerson %> </h6>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td style="text-align: center">
                        <%:  @Html.DropDownListFor(u => u.Personagem.Id_person, new SelectList(ViewBag.ListaPerson, "Id_person", "Desc_person"), new { @class = "dropdownlist", onchange= "document.location.href = '/Account/Personagem?Id_Person=' + this.options[this.selectedIndex].value;" })%>
                        <%: Html.HiddenFor(u => u.Personagem.Desc_person)%>
                        <%:  @Html.ValidationMessageFor(u => u.Personagem.Id_person)%>
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td colspan="2" style="text-align: center">
                        <div>
                            <input type="submit" value="Salvar" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </fieldset>
    <% } %>
</asp:Content>
