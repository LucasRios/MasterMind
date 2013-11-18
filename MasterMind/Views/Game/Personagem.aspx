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
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td style="text-align: center">
                        <%:  @Html.DropDownListFor(u => u.Personagem.Id_person, new SelectList(ViewBag.ListaPerson, "Id_person", "Desc_person"), new { @class = "dropdownlist"})%>
                        <%: Html.HiddenFor(u => u.Personagem.Desc_person)%>
                        <%:  @Html.ValidationMessageFor(u => u.Personagem.Id_person)%>
                    </td>
                </tr>
                <tr style="text-align: center">
                    <td style="text-align: center">
                        <img src="../../Images/usu.png" />
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
